using MediatR;

namespace BarberTech.Application.Commands.Users.Register
{
    public class CreateCommand : IRequest<Nothing>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? ImageSource { get; set; }
    }
}
