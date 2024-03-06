using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Queries.EventSchedules.GetAll
{
    public class GetSchedulesQuery : IRequest<Paged<GetSchedulesQueryResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string? SearchTerm { get; set; }
    }
}
