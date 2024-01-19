using FluentValidation;

namespace BarberTech.Application.Commands.Users.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email)
                //.EmailAddress() TODO: futuramente colocar essa verificação
                .NotEmpty();

            RuleFor(l => l.Password)
                .NotNull();
        }
    }
}
