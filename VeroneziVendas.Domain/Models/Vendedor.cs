using VeroneziVendas.Domain.Validators;

namespace VeroneziVendas.Domain.Models
{
    public class Vendedor : Entity
    {
        public string CPF { get; set; }

        public string Name { get; set; }

        public decimal? Salary { get; set; }

        public override bool EhValido() => Validate(this, new VendedorValidator());
    }
}
