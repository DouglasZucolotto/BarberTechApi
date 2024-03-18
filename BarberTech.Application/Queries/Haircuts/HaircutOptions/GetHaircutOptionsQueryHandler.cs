using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.HaircutOptions
{
    public class GetHaircutOptionsQueryHandler : IRequestHandler<GetHaircutOptionsQuery, IEnumerable<GetHaircutOptionsQueryResponse>>
    {
        private readonly IHaircutRepository _haircutRepository;

        public GetHaircutOptionsQueryHandler(IHaircutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<IEnumerable<GetHaircutOptionsQueryResponse>> Handle(GetHaircutOptionsQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "Name" };

            var haircuts = await _haircutRepository.GetAllFilteredAsync(request.SearchTerm, filterProps);

            return haircuts.Select(h => new GetHaircutOptionsQueryResponse()
            {
                Id = h.Id,
                Name = h.Name,
            });
        }
    }
}
