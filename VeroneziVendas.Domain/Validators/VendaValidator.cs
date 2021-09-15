using FluentValidation;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Domain.Validators
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id é obrigatório")
                              .GreaterThan(0).WithMessage("Id deve ser maior que 0 (zero)");
        }
    }
}
