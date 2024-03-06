using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQuery : IRequest<IEnumerable<string>?>
    {
        public Guid Id { get; set; }

        public string Date { get; set; } = string.Empty;

        public GetAvailableTimesQuery(Guid id, string date)
        {
            Id = id;
            Date = date;
        }
    }
}
