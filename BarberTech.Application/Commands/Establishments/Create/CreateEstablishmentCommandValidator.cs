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
                .NotNull();

            RuleFor(e => e.Longitude)
                .NotNull();

            RuleFor(e => e.ImageSource)
                .NotEmpty();

            //TODO: fazer regex
            RuleFor(e => e.OpenTime)
                .NotEmpty();

            RuleFor(e => e.LunchTime)
                .NotEmpty();

            RuleFor(e => e.WorkInterval)
                .NotEmpty();

            RuleFor(e => e.LunchInterval)
                .NotEmpty();
        }
    }
}
