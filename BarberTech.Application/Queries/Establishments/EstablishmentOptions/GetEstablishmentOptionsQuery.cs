using MediatR;

namespace BarberTech.Application.Queries.Establishments.EstablishmentOptions
{
    public class GetEstablishmentOptionsQuery : IRequest<IEnumerable<GetEstablishmentOptionsQueryResponse>>
    {
        public string? SearchTerm { get; set; }
    }
}
