using System.ComponentModel;

namespace VeroneziVendas.Domain.Models.Enum
{
    public enum TypeData
    {
        [Description("Vendedor")]
        Vendedor = 001,

        [Description("Cliente")]
        Cliente = 002,

        [Description("Venda")]
        Venda = 003
    }
}