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

            foreach (var _item in linhaSplit)
            {
                var _itemSpit = _item.Split("-").ToList();

                _itens.Add(new Item
                {
                    Id = Convert.ToInt32(_itemSpit[0]),
                    Quatity = Convert.ToInt32(_itemSpit[1]),
                    Price = Convert.ToDecimal(_itemSpit[2].Replace(",", "."), new CultureInfo("en-US")),
                });
            }

            return _itens;
        }
    }
}
