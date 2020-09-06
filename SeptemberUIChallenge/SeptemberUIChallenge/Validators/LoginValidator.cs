using FluentValidation;
using SeptemberUIChallenge.Models;

namespace SeptemberUIChallenge.Validators
{
    public class LoginValidator : AbstractValidator<LoginModel>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}