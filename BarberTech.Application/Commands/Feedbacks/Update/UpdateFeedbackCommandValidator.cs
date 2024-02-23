using FluentValidation;

namespace BarberTech.Application.Commands.Feedbacks.Update
{
    public class UpdateFeedbackCommandValidator : AbstractValidator<UpdateFeedbackCommand>
    {
        public UpdateFeedbackCommandValidator()
        {
            RuleFor(f => f.Id)
                .NotEmpty();

            RuleFor(f => f.RatingBarber)
                .ExclusiveBetween(0, 6);

            RuleFor(f => f.RatingEstablishment)
                .ExclusiveBetween(0, 6);

            RuleFor(f => f.RatingHaircut)
                .ExclusiveBetween(0, 6);
        }
    }
}
