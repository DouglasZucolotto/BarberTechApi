using FluentValidation;

namespace BarberTech.Application.Commands.EventSchedules.Create
{
    public class CreateEventScheduleCommandValidator : AbstractValidator<CreateEventScheduleCommand>
    {
        public CreateEventScheduleCommandValidator()
        {
            RuleFor(sh => sh.BarberId)
                .NotEmpty();

            RuleFor(sh => sh.HaircutId)
                .NotEmpty();

            RuleFor(sh => sh.DateTime)
                .NotEmpty()
                .Matches(@"^\d{2}/\d{2}/\d{4} \d{2}:\d{2}$")
                .WithMessage("A data deve estar no formato dd/mm/yyyy hh:mm");
        }
    }
}
