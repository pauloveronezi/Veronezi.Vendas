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
        public void Ler(string arquivo)
        {
            var _vendedores = new List<Vendedor>();
            var _clientes = new List<Cliente>();
            var _vendas = new List<Venda>();

            foreach (var _arquivo in Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "\\.data\\in"))
            {
                foreach (var _linha in File.ReadAllLines(_arquivo).ToList())
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
            }
        }

        public void Processar()
        {
            //var _quantidadeClientes = _clientes.Count;
            //var _quantidadeVendedores = _vendedores.Count;
            //var _vendaMaisCara = _vendas.Where(x => x.ValorVenda == _vendas.Max(x => x.ValorVenda)).Select(x => x.Id).SingleOrDefault();
            //var _teste = _vendas.GroupBy(g => new { g.Vendedor.Name, g.ValorVenda })
            //                    .Select(s => new { Name = s.Key.Name, Vendas = s.Sum(w => w.ValorVenda) }).ToList();

            //var _piorVendedor = _teste.Where(x => x.Vendas == _teste.Min(x => x.Vendas)).Select(x => x.Name).SingleOrDefault();

            //var _dataOut = $"{TypeDataOut.Out001}ç{_quantidadeClientes}ç{_quantidadeVendedores}ç{_vendaMaisCara}ç{_piorVendedor}";

            //try
            //{
            //    using (var fs = File.Create(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "\\.data\\out\\teste001_out.txt"))
            //    {
            //        byte[] info = new UTF8Encoding(true).GetBytes(_dataOut);
            //        fs.Write(info, 0, info.Length);
            //    }

            //    File.Move(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "\\.data\\in\\teste001.txt", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "\\.data\\processed\\teste001.txt");
            //}
            //catch (Exception)
            //{
            //    File.Move(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "\\.data\\in\\teste001.txt", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent + "\\.data\\error\\teste001.txt");
            //}
        }
    }
}
