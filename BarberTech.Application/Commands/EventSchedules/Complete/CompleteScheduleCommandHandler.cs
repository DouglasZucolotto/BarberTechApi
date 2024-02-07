using BarberTech.Domain;
using BarberTech.Domain.Entities.Enums;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.EventSchedules.Complete
{
    public class CompleteScheduleCommandHandler : IRequestHandler<CompleteScheduleCommand, Nothing>
    {
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly INotificationContext _notification;

        public CompleteScheduleCommandHandler(
            IEventScheduleRepository eventScheduleRepository,
            INotificationContext notification)
        {
            _notification = notification;
            _eventScheduleRepository = eventScheduleRepository;
        }

        public async Task<Nothing> Handle(CompleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var eventSchedule = await _eventScheduleRepository.GetByIdAsync(request.Id);

            if (eventSchedule is null)
            {
                _notification.AddNotFound("Event schedule does not exists");
                return default;
            }

            eventSchedule.EventStatus = EventStatus.Completed;

            _eventScheduleRepository.Update(eventSchedule);
            await _eventScheduleRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
