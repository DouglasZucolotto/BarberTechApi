using FluentValidation;

namespace BarberTech.Application.Commands.Haircuts.Delete
{
    public class DeleteHaircutCommandValidator : AbstractValidator<DeleteHaircutCommand>
    {
        public DeleteHaircutCommandValidator()
        {
            RuleFor(h => h.Id)
                .NotEmpty();
        }
    }
}
