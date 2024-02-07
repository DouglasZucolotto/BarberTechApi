using BarberTech.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Barbers.ScheduleHaircut
{
    public class ScheduleHaircutCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public Guid HaircutId { get; set; }

        public string? Name { get; set; }

        public string DateTime { get; set; } = string.Empty;

        public ScheduleHaircutCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
