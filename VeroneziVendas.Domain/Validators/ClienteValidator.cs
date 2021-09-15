using FluentValidation;
using VeroneziVendas.Domain.Models;

namespace VeroneziVendas.Domain.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.CNPJ).NotEmpty().WithMessage("CNPJ do Cliente é obrigatório")
                                .Length(14).WithMessage("CNPJ do Cliente deve possuir tamanho igual a 14 caracteres");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name do Cliente é obrigatório");
            RuleFor(x => x.BusinessArea).NotEmpty().WithMessage("BusinessArea do Cliente é obrigatório");
        }
    }
}
