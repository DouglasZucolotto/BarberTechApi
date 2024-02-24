using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableDates
{
    public class GetAvailableDatesQueryHandler : IRequestHandler<GetAvailableDatesQuery, IEnumerable<string>?>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly INotificationContext _notification;

        public GetAvailableDatesQueryHandler(IBarberRepository barberRepository, INotificationContext notification)
        {
            _barberRepository = barberRepository;
            _notification = notification;
        }

        public async Task<IEnumerable<string>?> Handle(GetAvailableDatesQuery request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetBarberByIdWithEventSchedulesAsync(request.Id);

            if (barber == null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            var availableDates = new List<DateTime>();
            var initialDate = DateTime.UtcNow;

            for (var date = DateTime.UtcNow; date < initialDate.AddDays(15); date = date.AddDays(1))
            {
                var availableTimes = barber.GetAvailableTimesByDateTime(date);

                if (availableTimes.Count() > 0)
                {
                    availableDates.Add(date);
                }
            }

            return availableDates.Select(date => date.ToString("dd/MM/yyyy"));
        }
    }
}
