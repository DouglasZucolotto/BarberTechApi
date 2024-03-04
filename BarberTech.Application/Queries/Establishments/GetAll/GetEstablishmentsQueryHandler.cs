using BarberTech.Domain;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetAll
{
    public class GetEstablishmentsQueryHandler : IRequestHandler<GetEstablishmentsQuery, Paged<GetEstablishmentsQueryResponse>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public GetEstablishmentsQueryHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<Paged<GetEstablishmentsQueryResponse>> Handle(GetEstablishmentsQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "Address" };

            var (items, totalCount) = await _establishmentRepository.GetAllPagedAsync(request.Page, request.PageSize, request.SearchTerm, filterProps);

            var establishments = items
                .Select(establishment => new GetEstablishmentsQueryResponse
                {
                    Id = establishment.Id,
                    Address = establishment.Address,
                    ImageSource = establishment.ImageSource,
                    BusinessTime = establishment.GetBusinessTime(),
                    Rating = establishment.GetRating(),
                })
                .OrderByDescending(establishment => establishment.Rating);

            return new Paged<GetEstablishmentsQueryResponse>(establishments, request.Page, request.PageSize, totalCount);
        }
    }
}
