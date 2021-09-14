using FluentValidation;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Domain.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id é obrigatório")
                              .GreaterThan(0).WithMessage("Id deve ser maior que 0 (zero)");
            RuleFor(x => x.Price).NotNull().WithMessage("Price é obrigatório")
                                 .GreaterThan(0).WithMessage("Price deve ser maior que 0 (zero)");
            RuleFor(x => x.Quatity).NotNull().WithMessage("Quantity é obrigatório")
                                   .GreaterThan(0).WithMessage("Quantity deve ser maior que 0 (zero)");
        }
    }
}
