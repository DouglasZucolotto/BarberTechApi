using FluentValidation;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommandValidator : AbstractValidator<UpdateEstablishmentCommand>
    {
        public UpdateEstablishmentCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();

            RuleFor(e => e.Address)
                .NotEmpty();

            RuleFor(e => e.Latitude)
                .NotNull();

            RuleFor(e => e.Longitude)
                .NotNull();

            RuleFor(e => e.ImageSource)
                .NotEmpty();

            RuleFor(e => e.BusinessHours)
                .NotEmpty();
        }
    }
}
