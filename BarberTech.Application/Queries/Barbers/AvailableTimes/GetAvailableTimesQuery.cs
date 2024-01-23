using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQuery : IRequest<IEnumerable<GetAvailableTimesQueryResponse>>
    {
        public Guid BarberId { get; set; }

        public GetAvailableTimesQuery(Guid barberId)
        {
            BarberId = barberId;
        }
    }
}
