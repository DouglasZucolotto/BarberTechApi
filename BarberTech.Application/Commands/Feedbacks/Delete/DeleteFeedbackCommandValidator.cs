using FluentValidation;

namespace BarberTech.Application.Commands.Feedbacks.Delete
{
    public class DeleteFeedbackCommandValidator : AbstractValidator<DeleteFeedbackCommand>
    {
        public DeleteFeedbackCommandValidator() 
        { 
            RuleFor(f => f.Id)
                .NotEmpty();
        }
    }
}
