using FluentValidation;

namespace BarberTech.Application.Commands.Establishments.Create
{
    public class CreateEstablishmentCommandValidator : AbstractValidator<CreateEstablishmentCommand>
    {
        public CreateEstablishmentCommandValidator()
        {
            RuleFor(e => e.Address)
                .NotNull();

            RuleFor(e => e.Latitude)
                .NotNull();

            RuleFor(e => e.Longitude)
                .NotNull();

            RuleFor(e => e.ImageSource)
                .NotNull();

            RuleFor(e => e.Description)
                .NotNull();

            RuleFor(e => e.BusinessHours)
                .NotNull();
        }
    }
}
