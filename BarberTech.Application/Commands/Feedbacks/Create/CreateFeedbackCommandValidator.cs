using FluentValidation;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
    {
        public CreateFeedbackCommandValidator()
        {
            RuleFor(f => f.QntStarsBarber)
                .ExclusiveBetween(0, 6)
                .NotNull();

            RuleFor(f => f.QntStarsEstablishment)
                .ExclusiveBetween(0, 6)
                .NotNull();

            RuleFor(f => f.QntStarsHaircut)
                .ExclusiveBetween(0, 6)
                .NotNull();

            RuleFor(f => f.EventScheduleId)
                .NotEmpty();
        }
    }
}
