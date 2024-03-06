using MediatR;

namespace BarberTech.Application.Queries.Establishments.EstablishmentOptions
{
    public class GetEstablishmentOptionsQuery : IRequest<IEnumerable<GetEstablishmentOptionsQueryResponse>>
    {
    }
}
