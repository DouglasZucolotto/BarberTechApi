using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQueryHandler : IRequestHandler<GetHaircutsQuery, PagedResponse<GetHaircutsQueryResponse>>
    {
        private readonly IHaircutRepository _haircutRepository;

        public GetHaircutsQueryHandler(IHaircutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<PagedResponse<GetHaircutsQueryResponse>> Handle(GetHaircutsQuery request, CancellationToken cancellationToken)
        {
            var queryResponse = await _haircutRepository.GetAllWithFeedbacksPagedAsync(request.Page, request.PageSize);

            var haircuts = queryResponse.Haircuts
                .Select(haircut => new GetHaircutsQueryResponse
                {
                    Id = haircut.Id,
                    Name = haircut.Name,
                    Description = haircut.Description,
                    ImageSource = haircut.ImageSource,
                    Price = haircut.Price,
                    QntStars = haircut.GetFeedbacksAverage(),
                });

            return new PagedResponse<GetHaircutsQueryResponse>(
                haircuts,
                request.Page,
                request.PageSize,
                queryResponse.Count);
        }
    }
}
