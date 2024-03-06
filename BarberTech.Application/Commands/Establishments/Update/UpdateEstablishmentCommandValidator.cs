using FluentValidation;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommandValidator : AbstractValidator<UpdateEstablishmentCommand>
    {
        public UpdateEstablishmentCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();

            RuleFor(e => e.OpenTime)
                .Matches("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$").WithMessage("Open time must be in the format hh:mm.");

            RuleFor(e => e.LunchTime)
                .Matches("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$").WithMessage("Lunch time must be in the format hh:mm.");

            RuleFor(e => e.WorkInterval)
                .Matches("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$").WithMessage("Work interval must be in the format hh:mm.");

            RuleFor(e => e.LunchInterval)
                .Matches("^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$").WithMessage("Lunch interval must be in the format hh:mm.");
        }
    }
}
