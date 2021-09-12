using System.ComponentModel;

namespace VeroneziVendas.Domain.Models.Enum
{
    public enum TypeDataIn
    {
        //Exemplo: 001çCPFçNameçSalary
        [Description("Vendedor")]
        Vendedor = 001,

        //Exemplo: 002çCNPJçNameçBusiness Area
        [Description("Cliente")]
        Cliente = 002,

        //Exemplo: 003çSale IDç[Item ID-Item Quantity-Item Price]çSalesman name
        [Description("Venda")]
        Venda = 003
    }
}