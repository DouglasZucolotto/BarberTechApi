namespace BarberTech.Application.Commands.Users.Register
{
    public class RegisterUserCommandResponse
    {
        public string Token { get; set; } = string.Empty;

        public Guid UserId { get; set; }
    }
}
