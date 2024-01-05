using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQuery : IRequest<IEnumerable<GetHaircutsQueryResponse>>
    {
    }
}
