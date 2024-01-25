using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.CancelSchedule
{
    public class CancelScheduleCommandHandler : IRequestHandler<CancelScheduleCommand, Nothing>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly INotificationContext _notification;

        public CancelScheduleCommandHandler(
            IBarberRepository barberRepository, 
            IEventScheduleRepository eventScheduleRepository,
            INotificationContext notification)
        {
            _barberRepository = barberRepository;
            _notification = notification;
            _eventScheduleRepository = eventScheduleRepository;
        }

        public async Task<Nothing> Handle(CancelScheduleCommand request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetByIdAsync(request.Id);

            if (barber is null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            var eventSchedule = await _eventScheduleRepository.GetByIdAsync(request.EventScheduleId);

            if (eventSchedule is null)
            {
                _notification.AddNotFound("Event Schedule does not exists");
                return default;
            }

            var eventExists = barber.EventSchedules.Any(es => es.Id == eventSchedule.Id);

            if(!eventExists)
            {
                _notification.AddBadRequest("Event Schedule does not belong to the barber");
                return default;
            }

            _eventScheduleRepository.Remove(eventSchedule);
            await _eventScheduleRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
