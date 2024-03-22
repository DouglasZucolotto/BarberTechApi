using BarberTech.Application.Queries.Barbers.Dtos;

namespace BarberTech.Application.Queries.Barbers.Calendar
{
    public class GetCalendarQueryResponse
    {
        public string Time { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;
    }
}
