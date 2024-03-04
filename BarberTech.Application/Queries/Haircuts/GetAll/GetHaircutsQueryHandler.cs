using BarberTech.Domain;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQueryHandler : IRequestHandler<GetHaircutsQuery, Paged<GetHaircutsQueryResponse>>
    {
        private readonly IHaircutRepository _haircutRepository;

        public GetHaircutsQueryHandler(IHaircutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<Paged<GetHaircutsQueryResponse>> Handle(GetHaircutsQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "Name", "Price" };

            var (items, totalCount) = await _haircutRepository.GetAllPagedAsync(request.Page, request.PageSize, request.SearchTerm, filterProps);

            var haircuts = items
                .Select(haircut => new GetHaircutsQueryResponse
                {
                    Id = haircut.Id,
                    Name = haircut.Name,
                    About = haircut.About,
                    ImageSource = haircut.ImageSource,
                    Price = haircut.Price,
                    Rating = haircut.GetRating(),
                });

            return new Paged<GetHaircutsQueryResponse>(haircuts, request.Page, request.PageSize, totalCount);
        }
    }
}
