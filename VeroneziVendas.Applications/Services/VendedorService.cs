using System;
using System.Collections.Generic;
using System.Globalization;
using VeroneziVendas.Applications.Interfaces;
using VeroneziVendas.Domain.Helper;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Services
{
    public class VendedorService : IVendedorService
    {
        public VendedorService()
        {

        }

        public Vendedor Criar(List<string> linhaSplit)
        {
            var _vendedor = new Vendedor
            {
                CPF = StringHelper.RemoveSimbolos(linhaSplit[1]),
                Name = linhaSplit[2],
                Salary = Convert.ToDecimal(linhaSplit[3].Replace(",", "."), new CultureInfo("en-US")),
            };

            return _vendedor;
        }
    }
}
