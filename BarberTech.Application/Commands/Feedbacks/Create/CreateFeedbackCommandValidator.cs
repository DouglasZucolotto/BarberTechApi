using FluentValidation;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
    {
        public CreateFeedbackCommandValidator()
        {
            RuleFor(f => f.QntStars)
                .ExclusiveBetween(-1, 6)
                .NotNull();

            RuleFor(f => f.EstablishmentId)
                .NotEmpty();

            RuleFor(f => f.HaircutId)
                .NotEmpty();

            RuleFor(f => f.BarberId)
                .NotEmpty();
        }
    }
}
