using FluentValidation;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.CNPJ).NotEmpty().WithMessage("CNPJ é obrigatório")
                                .Length(14).WithMessage("CNPJ deve possuir tamanho igual a 14 caracteres");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name é obrigatório");
            RuleFor(x => x.BusinessArea).NotEmpty().WithMessage("BusinessArea é obrigatório");
        }
    }
}
