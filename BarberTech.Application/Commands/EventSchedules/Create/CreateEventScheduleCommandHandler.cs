using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;
using System.Globalization;

namespace BarberTech.Application.Commands.EventSchedules.Create
{
    public class CreateEventScheduleCommandHandler : IRequestHandler<CreateEventScheduleCommand, Nothing>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly IHaircutRepository _haircutRepository;
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly INotificationContext _notification;
        private readonly IHttpContext _httpContext;

        public CreateEventScheduleCommandHandler(
            IBarberRepository barberRepository,
            IHaircutRepository haircutRepository,
            IEventScheduleRepository eventScheduleRepository,
            INotificationContext notification,
            IHttpContext httpContext)
        {
            _barberRepository = barberRepository;
            _haircutRepository = haircutRepository;
            _eventScheduleRepository = eventScheduleRepository;
            _notification = notification;
            _httpContext = httpContext;
        }

        public async Task<Nothing> Handle(CreateEventScheduleCommand request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetByIdWithSchedulesAsync(request.BarberId);

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

            var haircut = await _haircutRepository.GetByIdAsync(request.HaircutId);

            if (haircut is null)
            {
                _notification.AddNotFound("Haircut does not exists");
                return default;
            }

            var culture = new CultureInfo("pt-BR");
            var dateTime = DateTime.Parse(request.DateTime, culture);
            var availableTimes = barber.GetAvailableTimesByDateTime(dateTime);
            var time = request.DateTime.Split(' ')[1];
            var isTimeAvailable = availableTimes.Any(at => at.ToString(@"hh\:mm").Equals(time));

            if (!isTimeAvailable)
            {
                _notification.AddBadRequest("Time is not available");
                return default;
            }

            var dateTimeUniversal = dateTime.ToUniversalTime();

            var eventSchedule = new EventSchedule(user, barber, haircut, request.Name ?? user.Name, dateTimeUniversal);

            _eventScheduleRepository.Add(eventSchedule);
            await _eventScheduleRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
