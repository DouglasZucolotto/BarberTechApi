using BarberTech.Application.Queries.Barbers.GetAll;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQueryHandler : IRequestHandler<GetAvailableTimesQuery, IEnumerable<GetAvailableTimesQueryResponse>>
    {
        private readonly IBarberRepository _barberRepository;

        public GetAvailableTimesQueryHandler(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }
        public async Task<IEnumerable<GetAvailableTimesQueryResponse>> Handle(GetAvailableTimesQuery request, CancellationToken cancellationToken)
        {
            var times = await _barberRepository.GetAvailableTimesAsync();

            
        }
    }
}
