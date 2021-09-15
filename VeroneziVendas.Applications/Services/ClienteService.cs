using System;
using System.Collections.Generic;
using VeroneziVendas.Applications.Interfaces;
using VeroneziVendas.Domain.Helper;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Services
{
    public class ClienteService : IClienteService
    {
        public ClienteService()
        {

        }

        public Cliente Criar(List<string> linhaSplit)
        {
            var _cliente = new Cliente
            {
                CNPJ = StringHelper.RemoveSimbolos(linhaSplit[1]),
                Name = linhaSplit[2],
                BusinessArea = linhaSplit[3],
            };

            return _cliente;
        }
    }
}
