using BarberTech.Domain.Repositories;
using MediatR;
using BarberTech.Domain.Notifications;
using BarberTech.Application.Queries.Barbers.Dtos;

namespace BarberTech.Application.Queries.Barbers.Calendar
{
    public class GetCalendarQueryHandler : IRequestHandler<GetCalendarQuery, Dictionary<string, GetCalendarQueryResponse>>
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

        public async Task<Dictionary<string, GetCalendarQueryResponse>> Handle(GetCalendarQuery request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetByIdAsync(request.Id);

            if (barber == null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            var schedules = await _eventScheduleRepository.GetSchedulesByBarberId(request.Id);

            return schedules.ToDictionary(
                group => group.Key.Date.ToString("dd/MM/yyyy"),
                group => new GetCalendarQueryResponse
                {
                    Date = group.Key.Date.ToString("dd/MM/yyyy"),
                    Schedules = group.Value.Select(es => new EventScheduleDto
                    {
                        DateTime = es.DateTime.ToString("HH:mm"),
                        UserName = es.Name,
                    })
                });
        }
    }
}
