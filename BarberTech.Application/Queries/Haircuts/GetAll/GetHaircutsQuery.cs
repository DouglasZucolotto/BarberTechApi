using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQuery : IRequest<List<GetHaircutsQueryResponse>>
    {
    }
}
