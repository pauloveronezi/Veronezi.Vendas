namespace VeroneziVendas.Domain.Models
{
    public class Vendedor : Entity
    {
        public string CPF { get; set; }

        public string Name { get; set; }

        public string Salary { get; set; }
    }
}
