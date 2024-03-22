using FluentValidation;

namespace BarberTech.Application.Commands.Barbers.Create
{
    public class CreateBarberCommandValidator : AbstractValidator<CreateBarberCommand>
    {
        public CreateBarberCommandValidator()
        {
            RuleFor(b => b.EstablishmentId)
                .NotEmpty();

            RuleFor(b => b.UserId)
                .NotEmpty();

            RuleFor(b => b.Contact)
                .NotEmpty();

            RuleFor(b => b.Social)
                .NotNull();

            RuleFor(b => b.ImageSource)
                .NotNull();
        }
    }
}
