using FluentValidation;
using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(l => l.Email)
                //.EmailAddress()
                .NotEmpty();

            RuleFor(l => l.Password)
                .NotNull();
        }
    }
}
