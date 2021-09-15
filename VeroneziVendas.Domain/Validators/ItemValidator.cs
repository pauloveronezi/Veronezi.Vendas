using FluentValidation;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Domain.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id do Item é obrigatório")
                              .GreaterThan(0).WithMessage("Id do Item deve ser maior que 0 (zero)");
            RuleFor(x => x.Price).NotNull().WithMessage("Price do Item é obrigatório")
                                 .GreaterThan(0).WithMessage("Price do Item deve ser maior que 0 (zero)");
            RuleFor(x => x.Quatity).NotNull().WithMessage("Quantity do Item é obrigatório")
                                   .GreaterThan(0).WithMessage("Quantity do Item deve ser maior que 0 (zero)");
        }
    }
}
