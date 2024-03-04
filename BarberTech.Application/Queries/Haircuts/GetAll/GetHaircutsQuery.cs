using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQuery : IRequest<Paged<GetHaircutsQueryResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
