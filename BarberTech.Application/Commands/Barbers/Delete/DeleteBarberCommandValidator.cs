using BarberTech.Application.Commands.Establishments.Delete;
using FluentValidation;

namespace BarberTech.Application.Commands.Barbers.Delete
{
    public class DeleteBarberCommandValidator : AbstractValidator<DeleteBarberCommand>
    {
        public DeleteBarberCommandValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty();
        }
    }
}