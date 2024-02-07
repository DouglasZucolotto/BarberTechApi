using BarberTech.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.EventSchedules.Cancel
{
    public class CancelScheduleCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public CancelScheduleCommand(Guid id)
        {
            Id = id;
        }
    }
}
