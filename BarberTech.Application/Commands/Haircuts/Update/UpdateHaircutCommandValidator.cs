using FluentValidation;

namespace BarberTech.Application.Commands.Haircuts.Update
{
    public class UpdateHaircutCommandValidator : AbstractValidator<UpdateHaircutCommand>
    {
        public UpdateHaircutCommandValidator()
        {
            RuleFor(h => h.Id)
                .NotEmpty();
        }
    }
}
