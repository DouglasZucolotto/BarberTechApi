using FluentValidation;

namespace BarberTech.Application.Commands.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Email must be in a valid format");


            RuleFor(r => r.Password)
                .NotEmpty()
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[!@#$%^&*(),.?\":{}|<>]").WithMessage("Password must contain at least one special character.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.");

            RuleFor(r => r.Name)
                .NotNull();
        }
    }
}
