using BarberTech.Domain.Repositories;
using BarberTech.Infraestructure.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.EstablishmentOptions
{
    public class GetEstablishmentOptionsQueryHandler : IRequestHandler<GetEstablishmentOptionsQuery, IEnumerable<GetEstablishmentOptionsQueryResponse>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public GetEstablishmentOptionsQueryHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<IEnumerable<GetEstablishmentOptionsQueryResponse>> Handle(GetEstablishmentOptionsQuery request, CancellationToken cancellationToken)
        {
            var establishments = await _establishmentRepository.GetAllAsync();

            return establishments.Select(e => new GetEstablishmentOptionsQueryResponse()
            {
                Id = e.Id,
                Name = e.Address,
            });
        }
    }
}
