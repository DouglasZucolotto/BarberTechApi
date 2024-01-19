using FluentValidation;

namespace BarberTech.Application.Commands.Users.Delete
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty();
        }
    }
}
