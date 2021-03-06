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
                CNPJ = StringHelper.RemoveSimbolos(linhaSplit[1] ?? "0"),
                Name = linhaSplit[2] ?? string.Empty,
                BusinessArea = linhaSplit[3] ?? string.Empty,
            };

            //verificando se a entidade esta de acordo com as regras do validator
            _cliente.EhValido();

            return _cliente;
        }

        public string Errors(IEnumerable<Cliente> clientes)
        {
            var _errors = string.Empty;

            foreach (var item in clientes)
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
