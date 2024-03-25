using BarberTech.Domain.Repositories;
using MediatR;
using BarberTech.Domain.Notifications;

namespace BarberTech.Application.Queries.Barbers.Calendar
{
    public class GetCalendarQueryHandler : IRequestHandler<GetCalendarQuery, Dictionary<string, Dictionary<string, GetCalendarQueryResponse>>>
    {
        private readonly IEventScheduleRepository _eventScheduleRepository;
        private readonly IBarberRepository _barberRepository;
        private readonly INotificationContext _notification;

        public GetCalendarQueryHandler(
            IEventScheduleRepository eventScheduleRepository, 
            IBarberRepository barberRepository,
            INotificationContext notification)
        {
            _eventScheduleRepository = eventScheduleRepository;
            _barberRepository = barberRepository;
            _notification = notification;
        }

        public async Task<Dictionary<string, Dictionary<string, GetCalendarQueryResponse>>> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetByIdAsync(request.Id);

            if (barber == null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            var calendar = barber.GetCalendar();

            return calendar.ToDictionary(
                outerKvp => outerKvp.Key,
                outerKvp => outerKvp.Value.ToDictionary(
                    innerKvp => innerKvp.Key,
                    innerKvp => innerKvp.Value != null ? new GetCalendarQueryResponse
                    {
                        Id = innerKvp.Value.Id,
                        Time = innerKvp.Value?.DateTime.ToString("HH:mm"),
                        UserName = innerKvp.Value?.Name
                    } : null
                )
            );
        }
    }
}
