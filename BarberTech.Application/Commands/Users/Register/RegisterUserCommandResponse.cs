using BarberTech.Application.Commands.Users.Dtos;

namespace BarberTech.Application.Commands.Users.Register
{
    public class RegisterUserCommandResponse
    {
        public string Token { get; set; } = string.Empty;

        public UserDto User { get; set; }
    }
}
