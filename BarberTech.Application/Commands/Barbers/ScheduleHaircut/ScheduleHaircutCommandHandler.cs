using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.ScheduleHaircut
{
    public class ScheduleHaircutCommandHandler : IRequestHandler<ScheduleHaircutCommand, Nothing>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly INotificationContext _notification;
        private readonly IHttpContext _httpContext;

        public ScheduleHaircutCommandHandler(
            IBarberRepository barberRepository,
            IEventScheduleRepository eventScheduleRepository,
            INotificationContext notification,
            IHttpContext httpContext)
        {
            _barberRepository = barberRepository;
            _eventScheduleRepository = eventScheduleRepository;
            _notification = notification;
            _httpContext = httpContext;
        }

        public async Task<Nothing> Handle(ScheduleHaircutCommand request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetBarberByIdWithEventSchedulesAsync(request.Id);

            if (barber is null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            var user = await _httpContext.GetUserAsync();

            if (user is null)
            {
                _notification.AddNotFound("User does not exists");
                return default;
            }
            
            var dateTime = DateTime.Parse(request.DateTime);
            var availableTimes = barber.GetAvailableTimesByDateTime(dateTime);
            var time = request.DateTime.Split(' ')[1];
            var isTimeAvailable = availableTimes.Any(at => at.ToString(@"hh\:mm").Equals(time));

            if (!isTimeAvailable)
            {
                _notification.AddBadRequest("Time is not available");
                return default;
            }

            var dateTimeUniversal = DateTime.Parse(request.DateTime).ToUniversalTime();

            var eventSchedule = new EventSchedule(user, barber, request.Name ?? user.Name, dateTimeUniversal);

            _eventScheduleRepository.Add(eventSchedule);
            await _eventScheduleRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
