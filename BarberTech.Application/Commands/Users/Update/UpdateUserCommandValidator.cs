using FluentValidation;

namespace BarberTech.Application.Commands.Users.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty();

            RuleFor(r => r.Email)
                .EmailAddress().WithMessage("Email must be in a valid format");

            RuleFor(r => r.Password)
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Password must contain at least one special character.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.");
        }
    }
}
