using MediatR;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQuery : IRequest<IEnumerable<GetBarbersQueryResponse>>
    {
    }
}
