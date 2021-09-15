using FluentValidation;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Domain.Validators
{
    public class VendedorValidator : AbstractValidator<Vendedor>
    {
        public VendedorValidator()
        {
            RuleFor(x => x.CPF).NotEmpty().WithMessage("CPF do Vendedor é obrigatório")
                                .Length(11).WithMessage("CPF do Vendedor deve possuir tamanho igual a 11 caracteres");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name do Vendedor é obrigatório");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Salary do Vendedor é obrigatório");
        }
    }
}
