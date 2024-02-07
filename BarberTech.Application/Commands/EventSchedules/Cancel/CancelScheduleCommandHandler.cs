using BarberTech.Domain;
using BarberTech.Domain.Entities.Enums;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.EventSchedules.Cancel
{
    public class CancelScheduleCommandHandler : IRequestHandler<CancelScheduleCommand, Nothing>
    {
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly INotificationContext _notification;

        public CancelScheduleCommandHandler(
            IEventScheduleRepository eventScheduleRepository,
            INotificationContext notification)
        {
            _notification = notification;
            _eventScheduleRepository = eventScheduleRepository;
        }

        public async Task<Nothing> Handle(CancelScheduleCommand request, CancellationToken cancellationToken)
        {
            var eventSchedule = await _eventScheduleRepository.GetByIdAsync(request.Id);

            if (eventSchedule is null)
            {
                _notification.AddNotFound("Event schedule does not exists");
                return default;
            }

            eventSchedule.EventStatus = EventStatus.Canceled;

            _eventScheduleRepository.Update(eventSchedule);
            await _eventScheduleRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
