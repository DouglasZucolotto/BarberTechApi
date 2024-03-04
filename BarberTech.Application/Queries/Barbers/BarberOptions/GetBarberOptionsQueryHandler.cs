using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.BarberOptions
{
    public class GetBarberOptionsQueryHandler : IRequestHandler<GetBarberOptionsQuery, IEnumerable<GetBarberOptionsQueryResponse>>
    {
        private readonly IBarberRepository _barberRepository;

        public GetBarberOptionsQueryHandler(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        public async Task<IEnumerable<GetBarberOptionsQueryResponse>> Handle(GetBarberOptionsQuery request, CancellationToken cancellationToken)
        {
            var barbers = await _barberRepository.GetAllAsync();

            return barbers.Select(b => new GetBarberOptionsQueryResponse()
            {
                Id = b.Id,
                Name = b.Name,
            });
        }
    }
}
