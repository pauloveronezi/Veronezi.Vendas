using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using VeroneziVendas.Applications.Interfaces;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Services
{
    public class ItemService : IItemService
    {
        public ItemService()
        {

        }

        public IEnumerable<Item> Criar(List<string> linhaSplit)
        {
            var _itens = new List<Item>();

            foreach (var _linha in linhaSplit)
            {
                var _itemSpit = _linha.Split("-").ToList();

                var _item = new Item
                {
                    Id = Convert.ToInt32(_itemSpit[0] ?? "0"),
                    Quatity = Convert.ToInt32(_itemSpit[1] ?? "0"),
                    Price = Convert.ToDecimal((_itemSpit[2] ?? string.Empty).Replace(",", "."), new CultureInfo("en-US")),
                };

                _item.EhValido();

                _itens.Add(_item);
            }

            return _itens;
        }

        public string Errors(IEnumerable<Item> itens)
        {
            var _errors = string.Empty;

            foreach (var item in itens)
            {
                foreach (var error in item.ValidationResult?.Errors)
                {
                    _errors = string.Concat(_errors, $"{error.ErrorMessage}{Environment.NewLine}");
                }
            }

            return _errors;
        }
    }
}
