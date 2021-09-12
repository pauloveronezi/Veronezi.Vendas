using System.Collections.Generic;

namespace VeroneziVendas.Domain.Models
{
    public class Venda : Entity
    {
        public Vendedor Vendedor { get; set; }

        public IEnumerable<Item> ItemList { get; set; }
    }
}
