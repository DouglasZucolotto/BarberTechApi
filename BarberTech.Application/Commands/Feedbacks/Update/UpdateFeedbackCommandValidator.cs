using FluentValidation;

namespace BarberTech.Application.Commands.Feedbacks.Update
{
    public class UpdateFeedbackCommandValidator : AbstractValidator<UpdateFeedbackCommand>
    {
        public UpdateFeedbackCommandValidator()
        {
            RuleFor(f => f.Id)
                .NotEmpty();

            RuleFor(f => f.QntStarsBarber)
                .ExclusiveBetween(0, 6);

            RuleFor(f => f.QntStarsEstablishment)
                .ExclusiveBetween(0, 6);

            RuleFor(f => f.QntStarsHaircut)
                .ExclusiveBetween(0, 6);
        }
    }
}
