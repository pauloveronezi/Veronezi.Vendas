using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using VeroneziVendas.Applications.Interfaces;
using VeroneziVendas.Domain.Helper;
using VeroneziVendas.Domain.Models;
using VeroneziVendas.Domain.Models.Enum;

namespace VeroneziVendas.Applications.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IDiretorioService _ServiceDiretorio;
        private readonly IVendedorService _ServiceVendedor;
        private readonly IClienteService _ServiceCliente;
        private readonly IVendaService _ServiceVenda;

        public ArquivoService(IDiretorioService diretorioService,
                              IVendedorService vendedorService,
                              IClienteService clienteService,
                              IVendaService vendaService)
        {
            _ServiceDiretorio = diretorioService;
            _ServiceVendedor = vendedorService;
            _ServiceCliente = clienteService;
            _ServiceVenda = vendaService;
        }

        //metodo utilizado para ler os dados do arquivo, separa-los e transforma-los em entidades
        public Arquivo Ler(FileSystemEventArgs arquivo)
        {
            var _vendedores = new List<Vendedor>();
            var _clientes = new List<Cliente>();
            var _vendas = new List<Venda>();

            foreach (var _linha in File.ReadAllLines(arquivo.FullPath).ToList())
            {
                var _linhaSplit = _linha.Split("ç").ToList();

                if ((TypeDataIn)Convert.ToInt32(_linhaSplit[0]) == TypeDataIn.Vendedor)
                {
                    _vendedores.Add(_ServiceVendedor.Criar(_linhaSplit));
                }

                if ((TypeDataIn)Convert.ToInt32(_linhaSplit[0]) == TypeDataIn.Cliente)
                {
                    _clientes.Add(_ServiceCliente.Criar(_linhaSplit));
                }

                if ((TypeDataIn)Convert.ToInt32(_linhaSplit[0]) == TypeDataIn.Venda)
                {
                    _vendas.Add(_ServiceVenda.Criar(_linhaSplit));
                }
            }

            return Criar(_clientes, _vendedores, _vendas, arquivo);
        }

        //nesse metodo crio a entidade arquivo
        public Arquivo Criar(List<Cliente> clientes, List<Vendedor> vendedores, IEnumerable<Venda> vendas, FileSystemEventArgs arquivo = null)
        {
            var _arquivo = new Arquivo
            {
                Nome = arquivo.Name,
                Path = arquivo.FullPath,
                ClienteList = clientes,
                VendedorList = vendedores,
                VendaList = vendas.OrderBy(x => x.ValorVenda).ToList(),
            };

            _arquivo = ListarErrors(_arquivo);

            return _arquivo;
        }

        /*
         * metodo utilizado para retirar os dados requisitados pelo cliente no arquivo de saida (out):
         * Quantidade de clientes no arquivo de entrada;
         * Quantidade de vendedores no arquivo de entrada;
         * ID da venda mais cara;
         * O pior vendedor. 
         */
        public Arquivo Processar(Arquivo arquivo)
        {
            var _quantidadeClientes = arquivo.ClienteList?.ToList().Count;
            var _quantidadeVendedores = arquivo.VendedorList?.ToList().Count;

            var _vendaMaisCara = arquivo.VendaList?.LastOrDefault().Id;

            var _piorVendedor = arquivo.VendaList?
                                     .GroupBy(g => new { g.Vendedor.Name })
                                     .Select(s => new { s.Key.Name, Vendas = s.Sum(w => w.ValorVenda) })
                                     .OrderBy(o => o.Vendas)
                                     .FirstOrDefault().Name;

            //caso tenha erros de entidade (validator), os dados do arquivo de saida (out) serao os erros
            //caso contrario serao os dados requisitados pelo cliente
            var _dataOut = string.IsNullOrWhiteSpace(arquivo.Errors) ?
                                 $"{TypeDataOut.Out001}ç{_quantidadeClientes}ç{_quantidadeVendedores}ç{_vendaMaisCara}ç{_piorVendedor}" :
                                 arquivo.Errors;

            Salvar(arquivo, _dataOut);

            return arquivo;
        }

        //nesse metodo crio o arquivo no diretorio de saida
        public Arquivo Salvar(Arquivo arquivo, string dataOut)
        {
            var _diretorio = _ServiceDiretorio.Recuperar();

            using (var fs = File.Create($"{_diretorio}\\.data\\out\\{arquivo.Nome.Replace(".txt", $"_{DateTime.Now:ddMMyyyyHHmmss}out.txt")}"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(dataOut);
                fs.Write(info, 0, info.Length);
            }

            return arquivo;
        }        

        //nesse metodo busco os erros, caso tenha
        private Arquivo ListarErrors(Arquivo arquivo)
        {
            arquivo.Errors += _ServiceVendedor.Errors(arquivo.VendedorList);
            arquivo.Errors += _ServiceCliente.Errors(arquivo.ClienteList);
            arquivo.Errors += _ServiceVenda.Errors(arquivo.VendaList);

            return arquivo;
        }
    }
}
