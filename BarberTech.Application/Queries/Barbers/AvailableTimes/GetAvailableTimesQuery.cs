using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQuery : IRequest<IEnumerable<string>>
    {
        public Guid BarberId { get; set; }

        public GetAvailableTimesQuery(Guid barberId)
        {
            BarberId = barberId;
        }
    }
}
