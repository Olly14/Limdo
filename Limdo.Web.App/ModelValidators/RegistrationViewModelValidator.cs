using FluentValidation;
using Limdo.Web.App.Models;


namespace Limdo.Web.App.ModelValidators
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistratioViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                    .WithMessage("'Email' is required");
            RuleFor(r => r.Password)
                .NotEmpty()
                    .WithMessage("'Password' is required");
            RuleFor(r => r.ConfirmedPassword)
                .NotEmpty()
                    .WithMessage("'Confirmed password' is required");
        }
    }
}
