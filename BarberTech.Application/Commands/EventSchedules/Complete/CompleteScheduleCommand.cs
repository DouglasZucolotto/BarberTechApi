using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.EventSchedules.Complete
{
    public class CompleteScheduleCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public CompleteScheduleCommand(Guid id)
        {
            Id = id;
        }
    }
}
