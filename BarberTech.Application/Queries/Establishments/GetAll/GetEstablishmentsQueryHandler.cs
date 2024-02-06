using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetAll
{
    public class GetEstablishmentsQueryHandler : IRequestHandler<GetEstablishmentsQuery, IEnumerable<GetEstablishmentsQueryResponse>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public GetEstablishmentsQueryHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<IEnumerable<GetEstablishmentsQueryResponse>> Handle(GetEstablishmentsQuery request, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.GetAllAsync();

            return establishments
                .Select(establishment => new GetEstablishmentsQueryResponse
                {
                    Id = establishment.Id,
                    Address = establishment.Address,
                    Latitude = establishment.Coordinates.Y,
                    Longitude = establishment.Coordinates.X,
                    BusinessTime = establishment.GetBusinessTime(),
                    QntStars = establishment.GetFeedbacksAverage(),
                });
        }
    }
}
