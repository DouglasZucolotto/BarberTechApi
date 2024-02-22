namespace BarberTech.Application.Commands.Users.Dtos
{
    public class EventScheduleDto
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
