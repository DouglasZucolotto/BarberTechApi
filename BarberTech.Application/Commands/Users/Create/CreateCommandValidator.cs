using FluentValidation;

namespace BarberTech.Application.Commands.Users.Register
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
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
