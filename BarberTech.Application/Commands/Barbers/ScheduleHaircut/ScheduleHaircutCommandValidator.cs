using FluentValidation;

namespace BarberTech.Application.Commands.Barbers.ScheduleHaircut
{
    public class ScheduleHaircutCommandValidator : AbstractValidator<ScheduleHaircutCommand>
    {
        public ScheduleHaircutCommandValidator()
        {
            RuleFor(sh => sh.BarberId)
                .NotEmpty();

            RuleFor(sh => sh.EstablishmentId)
                .NotEmpty();

            RuleFor(sh => sh.DateTime)
                .NotEmpty()
                .Matches(@"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}$")
                .WithMessage("A data deve estar no formato dd/MM/yyyy HH:mm");
        }
    }
}
