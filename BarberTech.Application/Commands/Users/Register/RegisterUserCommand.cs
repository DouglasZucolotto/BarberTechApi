using BarberTech.Domain.Entities;
using MediatR;

namespace BarberTech.Application.Commands.Users.Register
{
    public class RegisterUserCommand : IRequest<User>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public RegisterUserCommand(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }
    }
}
