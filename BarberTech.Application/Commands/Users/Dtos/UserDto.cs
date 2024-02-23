namespace BarberTech.Application.Commands.Users.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string? ImageSource { get; set; }
    }
}
