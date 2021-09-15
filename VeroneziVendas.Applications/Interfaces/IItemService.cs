using System.Collections.Generic;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Applications.Interfaces
{
    public interface IItemService
    {
        IEnumerable<Item> Criar(List<string> linhaSplit);

        string Errors(IEnumerable<Item> itens);
    }
}
