using VeroneziVendas.Domain.Validators;

namespace VeroneziVendas.Domain.Models
{
    public class Item : Entity
    {
        public int? Quatity { get; set; }

        public decimal? Price { get; set; }

        public override bool EhValido() => Validate(this, new ItemValidator());
    }
}
