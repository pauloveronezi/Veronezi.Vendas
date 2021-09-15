using VeroneziVendas.Domain.Validators;

namespace VeroneziVendas.Domain.Models
{
    public class Cliente : Entity
    {
        public string CNPJ { get; set; }

        public string Name { get; set; }

        public string BusinessArea { get; set; }

        public override bool EhValido() => Validate(this, new ClienteValidator());
    }
}
