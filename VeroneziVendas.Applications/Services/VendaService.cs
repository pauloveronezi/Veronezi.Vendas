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
                Id = Convert.ToInt32(linhaSplit[1]),
                ItemList = _ServiceItem.Criar(linhaSplit[2].Replace("[", "").Replace("]", "").Split(",").ToList()),
                Vendedor = new Vendedor { Name = linhaSplit[3] },
            };

            return _vendas;
        }
    }
}
