using BarberTech.Application.Commands.Establishments.Delete;
using FluentValidation;

namespace BarberTech.Application.Commands.Barbers.CancelSchedule
{
    public class CancelScheduleCommandValidator : AbstractValidator<CancelScheduleCommand>
    {
        public CancelScheduleCommandValidator()
        {
            RuleFor(cs => cs.Id)
                .NotEmpty();

            RuleFor(cs => cs.EventScheduleId)
                .NotEmpty();

            RuleFor(cs => cs.Reason)
                .NotEmpty();
        }
    }
}