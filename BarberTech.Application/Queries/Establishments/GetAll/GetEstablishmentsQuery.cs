using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetAll
{
    public class GetEstablishmentsQuery : IRequest<Paged<GetEstablishmentsQueryResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
