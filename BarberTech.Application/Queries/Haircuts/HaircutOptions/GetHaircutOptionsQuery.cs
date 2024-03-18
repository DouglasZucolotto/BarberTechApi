using MediatR;

namespace BarberTech.Application.Queries.Haircuts.HaircutOptions
{
    public class GetHaircutOptionsQuery : IRequest<IEnumerable<GetHaircutOptionsQueryResponse>>
    {
        public string? SearchTerm { get; set; }
    }
}
