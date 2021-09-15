using FluentValidation;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Domain.Validators
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id da Venda é obrigatório")
                              .GreaterThan(0).WithMessage("Id da Venda deve ser maior que 0 (zero)");
        }
    }
}
