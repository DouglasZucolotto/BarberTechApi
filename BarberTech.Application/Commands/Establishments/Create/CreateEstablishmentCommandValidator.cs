using FluentValidation;

namespace BarberTech.Application.Commands.Establishments.Create
{
    public class CreateEstablishmentCommandValidator : AbstractValidator<CreateEstablishmentCommand>
    {
        public CreateEstablishmentCommandValidator()
        {
            RuleFor(e => e.Address)
                .NotEmpty();

            RuleFor(e => e.Latitude)
                .NotNull()
                .Equal(1);

            RuleFor(e => e.Longitude)
                .NotNull();

            RuleFor(e => e.ImageSource)
                .NotEmpty();

            RuleFor(e => e.BusinessHours)
                .NotEmpty();
        }
    }
}
