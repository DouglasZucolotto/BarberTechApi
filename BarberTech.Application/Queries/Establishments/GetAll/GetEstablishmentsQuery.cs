using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetAll
{
    public class GetEstablishmentsQuery : IRequest<IEnumerable<GetEstablishmentsQueryResponse>>
    {
    }
}
