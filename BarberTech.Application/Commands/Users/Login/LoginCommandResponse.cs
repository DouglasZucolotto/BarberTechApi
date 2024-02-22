using BarberTech.Application.Commands.Users.Dtos;

namespace BarberTech.Application.Commands.Users.Login
{
    public class LoginCommandResponse
    {
        public string Token { get; set; } = string.Empty;

        public UserDto User { get; set; }
    }
}
