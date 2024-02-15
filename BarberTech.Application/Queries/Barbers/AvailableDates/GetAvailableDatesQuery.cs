using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableDates
{
    public class GetAvailableDatesQuery : IRequest<IEnumerable<string>?>
    {
        public Guid Id { get; set; }

        public GetAvailableDatesQuery(Guid id)
        {
            Id = id;
        }
    }
}
