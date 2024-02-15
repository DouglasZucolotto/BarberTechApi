using MediatR;

namespace BarberTech.Application.Queries.Barbers.BarberOptions
{
    public class GetBarberOptionsQuery : IRequest<IEnumerable<GetBarberOptionsQueryResponse>>
    {
    }
}
