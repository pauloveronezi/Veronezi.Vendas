using System;
using System.Collections.Generic;
using System.Linq;
using VeroneziVendas.Applications.Interfaces;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Services
{
    public class VendaService : IVendaService
    {
        private readonly IItemService _ServiceItem;

        public VendaService(IItemService itemService)
        {
            _ServiceItem = itemService;
        }

        public Venda Criar(List<string> linhaSplit)
        {
            var _vendas = new Venda
            {
                Id = Convert.ToInt32(linhaSplit[1] ?? "0"),
                ItemList = _ServiceItem.Criar((linhaSplit[2] ?? "0-0-0").Replace("[", "").Replace("]", "").Split(",").ToList()),
                Vendedor = new Vendedor { Name = linhaSplit[3] ?? string.Empty },
            };

            _vendas.EhValido();

            return _vendas;
        }

        public string Errors(IEnumerable<Venda> vendas)
        {
            var _errors = string.Empty;

            foreach (var _venda in vendas)
            {
                _errors = string.Concat(_errors, _ServiceItem.Errors(_venda.ItemList));

                foreach (var error in _venda.ValidationResult?.Errors)
                {
                    _errors = string.Concat(_errors, $"{error.ErrorMessage}{Environment.NewLine}");
                }
            }

            return _errors;
        }
    }    
}
