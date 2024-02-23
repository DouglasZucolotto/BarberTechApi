using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetAll
{
    public class GetEstablishmentsQueryHandler : IRequestHandler<GetEstablishmentsQuery, PagedResponse<GetEstablishmentsQueryResponse>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public GetEstablishmentsQueryHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<PagedResponse<GetEstablishmentsQueryResponse>> Handle(GetEstablishmentsQuery request, CancellationToken cancellationToken)
        {
            var queryResponse = await _establishmentRepository.GetAllWithFeedbacksPagedAsync(request.Page, request.PageSize);

            var establishments = queryResponse.Establishments
                .Select(establishment => new GetEstablishmentsQueryResponse
                {
                    Id = establishment.Id,
                    Address = establishment.Address,
                    ImageSource = establishment.ImageSource,
                    Latitude = establishment.Coordinates.Y,
                    Longitude = establishment.Coordinates.X,
                    BusinessTime = establishment.GetBusinessTime(),
                    QntStars = establishment.GetFeedbacksAverage(),
                });


            return new PagedResponse<GetEstablishmentsQueryResponse>(
                establishments,
                request.Page,
                request.PageSize,
                queryResponse.Count);
        }
    }
}
