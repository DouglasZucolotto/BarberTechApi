using FluentValidation;

namespace BarberTech.Application.Commands.EventSchedules.Cancel
{
    public class CancelScheduleCommandValidator : AbstractValidator<CancelScheduleCommand>
    {
        public CancelScheduleCommandValidator()
        {
            RuleFor(cs => cs.Id)
                .NotEmpty();
        }
    }
}