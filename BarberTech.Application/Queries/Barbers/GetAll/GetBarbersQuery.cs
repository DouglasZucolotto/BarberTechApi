using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQuery : IRequest<Paged<GetBarbersQueryResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string? SearchTerm { get; set; }
    }
}
