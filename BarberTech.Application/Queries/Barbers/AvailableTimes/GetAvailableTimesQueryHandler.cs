using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQueryHandler : IRequestHandler<GetAvailableTimesQuery, IEnumerable<string>>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly INotificationContext _notification;

        public GetAvailableTimesQueryHandler(IBarberRepository barberRepository, INotificationContext notification)
        {
            _barberRepository = barberRepository;
            _notification = notification;
        }

        public async Task<IEnumerable<string>> Handle(GetAvailableTimesQuery request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetBarberByIdWithEventSchedulesAsync(request.BarberId);

            if (barber == null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }


            //pega o mes e retorna os dias disponiveis (novo endpoint)

            // EventSchedule - (talvez n precise da fk establishment)



            //Passar por request
            var requestDate = new DateTime(2024, 01, 01);

            var events = barber.EventSchedules.Where(es => es.DateTime.Date == requestDate);
            var establishment = barber.Establishment;
            var availableTimes = new List<TimeSpan>();
            var closeTime = establishment.OpenTime.Add(establishment.WorkInterval + establishment.LunchInterval);

            for (var time = establishment.OpenTime; time < closeTime; time += TimeSpan.FromMinutes(30)) 
            {
                var isLunchInterval = time >= establishment.LunchTime && time < establishment.LunchTime.Add(establishment.LunchInterval);
                var anyEvent = events.Any(e => e.DateTime.TimeOfDay == time);

                if (!anyEvent && !isLunchInterval)
                {
                    availableTimes.Add(time);
                }
            }

            return availableTimes.Select(time => time.ToString());
        }
    }
}
