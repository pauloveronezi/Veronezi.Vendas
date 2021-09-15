using System.Collections.Generic;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IClienteService
    {
        Cliente Criar(List<string> linhaSplit);
    }
}
