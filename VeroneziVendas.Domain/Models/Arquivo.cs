﻿using System.Collections.Generic;

namespace VeroneziVendas.Domain.Models
{
    public class Arquivo
    {
        public string Nome { get; set; }

        public string Path { get; set; }

        public IEnumerable<Vendedor> VendedorList { get; set; }

        public IEnumerable<Cliente> ClienteList { get; set; }

        public IEnumerable<Venda> VendaList { get; set; }
    }
}
