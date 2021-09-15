using System.Collections.Generic;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IVendedorService
    {
        Vendedor Criar(List<string> linhaSplit);

        string Errors(IEnumerable<Vendedor> vendedores);
    }
}
