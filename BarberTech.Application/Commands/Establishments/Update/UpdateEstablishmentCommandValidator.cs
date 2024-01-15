using FluentValidation;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommandValidator : AbstractValidator<UpdateEstablishmentCommand>
    {
        public UpdateEstablishmentCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();

            RuleFor(e => e.Latitude)
                .NotNull()
                .When(e => e.Longitude.HasValue);

            RuleFor(e => e.Longitude)
                .NotNull()
                .When(e => e.Latitude.HasValue);
        }
    }
}
