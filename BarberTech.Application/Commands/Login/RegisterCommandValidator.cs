using FluentValidation;

namespace BarberTech.Application.Commands.Login
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.Email)
                //.EmailAddress() TODO: futuramente colocar essa verificação
                .NotEmpty();

            RuleFor(r => r.Password)
                .NotNull(); // TODO: definir regras da senha

            RuleFor(r => r.Name)
                .NotNull();
        }
    }
}
