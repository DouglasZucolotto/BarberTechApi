using FluentValidation;

namespace BarberTech.Application.Commands.EventSchedules.Complete
{
    public class CompleteScheduleCommandValidator : AbstractValidator<CompleteScheduleCommand>
    {
        public CompleteScheduleCommandValidator()
        {
            RuleFor(cs => cs.Id)
                .NotEmpty();
        }
    }
}