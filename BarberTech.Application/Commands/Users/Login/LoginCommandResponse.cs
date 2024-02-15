namespace BarberTech.Application.Commands.Users.Login
{
    public class LoginCommandResponse
    {
        public string Token { get; set; } = string.Empty;

        public Guid UserId { get; set; }
    }
}
