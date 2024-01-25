using BarberTech.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Barbers.CancelSchedule
{
    public class CancelScheduleCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public Guid EventScheduleId { get; set; }

        public string Reason { get; set; } = string.Empty;

        public CancelScheduleCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
