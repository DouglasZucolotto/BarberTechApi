using FluentValidation;

namespace BarberTech.Application.Commands.Feedbacks.Update
{
    public class UpdateFeedbackCommandValidator : AbstractValidator<UpdateFeedbackCommand>
    {
        public UpdateFeedbackCommandValidator()
        {
            RuleFor(f => f.Id)
                .NotEmpty();
        }
    }
}
