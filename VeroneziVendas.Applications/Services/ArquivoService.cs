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

        public ArquivoService(IServiceProvider serviceProvider, IDiretorioService diretorioService)
        {
            _ServiceDiretorio = diretorioService;
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
                    _vendedores.Add(new Vendedor
                    {
                        CPF = _linhaSplit[1].RemoveSimbolos(),
                        Name = _linhaSplit[2],
                        Salary = _linhaSplit[3],
                    });
                }

                if ((TypeDataIn)Convert.ToInt32(_linhaSplit[0]) == TypeDataIn.Cliente)
                {
                    _clientes.Add(new Cliente
                    {
                        CNPJ = _linhaSplit[1].RemoveSimbolos(),
                        Name = _linhaSplit[2],
                        BusinessArea = _linhaSplit[3],
                    });
                }

                if ((TypeDataIn)Convert.ToInt32(_linhaSplit[0]) == TypeDataIn.Venda)
                {
                    var _itens = new List<Item>();

                    foreach (var _item in _linhaSplit[2].Replace("[", "").Replace("]", "").Split(",").ToList())
                    {
                        var _itemSpit = _item.Split("-").ToList();

                        _itens.Add(new Item
                        {
                            Id = Convert.ToInt32(_itemSpit[0]),
                            Quatity = Convert.ToInt32(_itemSpit[1]),
                            Price = Convert.ToDecimal(_itemSpit[2].Replace(",", "."), new CultureInfo("en-US")),
                        });
                    }

                    _vendas.Add(new Venda
                    {
                        Id = Convert.ToInt32(_linhaSplit[1]),
                        ItemList = _itens,
                        Vendedor = new Vendedor { Name = _linhaSplit[3] },
                    });
                }
            }

            var _arquivo = new Arquivo
            {
                Nome = arquivo.Name,
                Path = arquivo.FullPath,
                ClienteList = _clientes,
                VendaList = _vendas,
                VendedorList = _vendedores
            };

            return _arquivo;
        }

        public Arquivo Salvar(Arquivo arquivo, string dataOut)
        {
            var _diretorio = _ServiceDiretorio.Recuperar();

            try
            {
                using (var fs = File.Create($"{_diretorio}\\.data\\out\\{arquivo.Nome.Replace(".txt", $"_{DateTime.Now:ddMMyyyyhhmmss}out.txt")}"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(dataOut);
                    fs.Write(info, 0, info.Length);
                }

                File.Move($"{_diretorio}\\.data\\in\\{arquivo.Nome}", $"{_diretorio}\\.data\\processed\\{arquivo.Nome.Replace(".txt", $"_{DateTime.Now:ddMMyyyyhhmmss}processed.txt")}");
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
            var _vendaMaisCara = arquivo.VendaList.Where(x => x.ValorVenda == arquivo.VendaList.Max(x => x.ValorVenda)).Select(x => x.Id).SingleOrDefault();

            var _teste = arquivo.VendaList.GroupBy(g => new { g.Vendedor.Name, g.ValorVenda })
                                .Select(s => new { s.Key.Name, Vendas = s.Sum(w => w.ValorVenda) })
                                .ToList();
            var _piorVendedor = _teste.Where(x => x.Vendas == _teste.Min(x => x.Vendas)).Select(x => x.Name).SingleOrDefault();

            var _dataOut = $"{TypeDataOut.Out001}ç{_quantidadeClientes}ç{_quantidadeVendedores}ç{_vendaMaisCara}ç{_piorVendedor}";

            Salvar(arquivo, _dataOut);

            return arquivo;
        }
    }
}
