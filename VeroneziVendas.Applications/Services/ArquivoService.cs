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

        public Arquivo Salvar(Arquivo arquivo, string dataOut)
        {
            var _diretorio = _ServiceDiretorio.Recuperar();

            try
            {
                using (var fs = File.Create($"{_diretorio}\\.data\\out\\{arquivo.Nome.Replace(".txt", $"_{DateTime.Now:ddMMyyyyHHmmss}out.txt")}"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(dataOut);
                    fs.Write(info, 0, info.Length);
                }

                File.Move($"{_diretorio}\\.data\\in\\{arquivo.Nome}", $"{_diretorio}\\.data\\processed\\{arquivo.Nome.Replace(".txt", $"_{DateTime.Now:ddMMyyyyHHmmss}processed.txt")}");
            }
            catch (Exception)
            {
                File.Move($"{_diretorio}\\.data\\in\\{arquivo.Nome}", $"{_diretorio}\\.data\\error\\{arquivo.Nome.Replace(".txt", $"_{DateTime.Now:ddMMyyyyhhmmss}error.txt")}");
            }

            return arquivo;
        }

        public Arquivo Processar(Arquivo arquivo)
        {
            var _quantidadeClientes = arquivo.ClienteList.ToList().Count;
            var _quantidadeVendedores = arquivo.VendedorList.ToList().Count;

            var _vendaMaisCara = arquivo.VendaList.LastOrDefault().Id;

            var _piorVendedor = arquivo.VendaList
                                     .GroupBy(g => new { g.Vendedor.Name })
                                     .Select(s => new { s.Key.Name, Vendas = s.Sum(w => w.ValorVenda) })
                                     .OrderBy(o => o.Vendas)
                                     .FirstOrDefault().Name;

            var _dataOut = $"{TypeDataOut.Out001}ç{_quantidadeClientes}ç{_quantidadeVendedores}ç{_vendaMaisCara}ç{_piorVendedor}";

            Salvar(arquivo, _dataOut);

            return arquivo;
        }

        public Arquivo Criar(List<Cliente> clientes, List<Vendedor> vendedores, List<Venda> vendas, FileSystemEventArgs arquivo = null)
        {
            var _arquivo = new Arquivo
            {
                Nome = arquivo.Name,
                Path = arquivo.FullPath,
                ClienteList = clientes,
                VendedorList = vendedores,
                VendaList = vendas.OrderBy(x => x.ValorVenda).ToList(),
            };

            return _arquivo;
        }
    }
}
