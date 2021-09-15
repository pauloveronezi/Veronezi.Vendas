using FluentValidation;
using FluentValidation.Results;

namespace VeroneziVendas.Domain.Models
{
    public class Entity
    {
        public long Id { get; set; }

        #region Validator

        public virtual bool EhValido() => true;

        public ValidationResult ValidationResult { get; set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return ValidationResult.IsValid;
        }

        #endregion
    }
}
