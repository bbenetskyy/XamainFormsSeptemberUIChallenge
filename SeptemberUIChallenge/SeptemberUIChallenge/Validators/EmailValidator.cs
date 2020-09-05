using FluentValidation;

namespace SeptemberUIChallenge.Validators
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .EmailAddress();
        }
    }
}