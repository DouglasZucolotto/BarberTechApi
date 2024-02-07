using FluentValidation;

namespace BarberTech.Application.Commands.Users.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Email must be in a valid format");

            RuleFor(l => l.Password)
                .NotEmpty();
        }
    }
}
