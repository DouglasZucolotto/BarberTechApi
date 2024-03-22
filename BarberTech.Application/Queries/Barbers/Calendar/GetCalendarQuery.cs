using MediatR;

namespace BarberTech.Application.Queries.Barbers.Calendar
{
    public class GetCalendarQuery : IRequest<Dictionary<string, IEnumerable<GetCalendarQueryResponse>>>
    {
        public Guid Id { get; set; }

        public GetCalendarQuery(Guid id)
        {
            Id = id;
        }
    }
}
