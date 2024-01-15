using FluentValidation;

namespace BarberTech.Application.Commands.Haircuts.Create
{
    public class CreateHaircutCommandValidator : AbstractValidator<CreateHaircutCommand>
    {
        public CreateHaircutCommandValidator()
        {
            RuleFor(h => h.Name)
                .NotEmpty();

            RuleFor(h => h.Price)
                .NotNull();

            RuleFor(h => h.ImageSource)
                .NotEmpty();
        }
    }
}
