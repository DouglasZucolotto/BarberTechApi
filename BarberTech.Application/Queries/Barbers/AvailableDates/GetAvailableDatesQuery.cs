using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableDates
{
    public class GetAvailableDatesQuery : IRequest<IEnumerable<GetAvailableDatesQueryResponse>?>
    {
        public Guid Id { get; set; }

        public GetAvailableDatesQuery(Guid id)
        {
            Id = id;
        }
    }
}
