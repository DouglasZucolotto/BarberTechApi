using MediatR;

namespace BarberTech.Application.Queries.Haircuts
{
    public class GetHaircutsQuery : IRequest<List<GetHaircutsQueryResponse>>
    {
    }
}
