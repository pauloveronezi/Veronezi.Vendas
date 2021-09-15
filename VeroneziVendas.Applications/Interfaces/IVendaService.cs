using System.Collections.Generic;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IVendaService
    {
        Venda Criar(List<string> linhaSplit);
    }
}
