using BarberTech.Application.Queries.Barbers.Dtos;

namespace BarberTech.Application.Queries.Barbers.Calendar
{
    public class GetCalendarQueryResponse
    {
        public string Date { get; set; } = string.Empty;

        public IEnumerable<EventScheduleDto> Schedules { get; set; } = Enumerable.Empty<EventScheduleDto>();
    }
}
