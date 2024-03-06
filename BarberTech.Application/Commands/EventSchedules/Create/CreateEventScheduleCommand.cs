using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.EventSchedules.Create
{
    public class CreateEventScheduleCommand : IRequest<Nothing>
    {
        public Guid BarberId { get; set; }

        public Guid HaircutId { get; set; }

        public string? Name { get; set; }

        public string DateTime { get; set; } = string.Empty;
    }
}
