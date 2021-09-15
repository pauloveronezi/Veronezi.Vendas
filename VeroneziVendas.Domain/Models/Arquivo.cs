using System.Collections.Generic;
using VeroneziVendas.Domain.Validators;

namespace VeroneziVendas.Domain.Models
{
    public class Arquivo : Entity
    {
        public string Nome { get; set; }

        public string Path { get; set; }

        public string Errors { get; set; }

        public IEnumerable<Vendedor> VendedorList { get; set; }

        public IEnumerable<Cliente> ClienteList { get; set; }

        public IEnumerable<Venda> VendaList { get; set; }
    }
}
