using MediatR;

namespace BarberTech.Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<RegisterUserCommandResponse?>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? ImageSource { get; set; }

        public RegisterUserCommand(string email, string password, string name, string? imageSource)
        {
            Email = email;
            Password = password;
            Name = name;
            ImageSource = imageSource;
        }
    }
}
