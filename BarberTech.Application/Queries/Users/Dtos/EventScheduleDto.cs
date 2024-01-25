namespace BarberTech.Application.Queries.Users.Dtos
{
    public class EventScheduleDto
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}
