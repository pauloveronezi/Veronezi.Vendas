using System.Collections.Generic;
using System.Linq;

namespace VeroneziVendas.Domain.Models
{
    public class Venda : Entity
    {
        public Vendedor Vendedor { get; set; }

        public IEnumerable<Item> ItemList { get; set; }
        
        public decimal ValorVenda
        {
            get
            {
                return ItemList?.Sum(x => x.Price) ?? 0;
            }            
        }
    }
}
