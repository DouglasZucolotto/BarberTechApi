using FluentValidation;

namespace BarberTech.Application.Commands.Establishments.Delete
{
    public class DeleteEstablishmentCommandValidator : AbstractValidator<DeleteEstablishmentCommand>
    {
        public DeleteEstablishmentCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();
        }
    }
}
