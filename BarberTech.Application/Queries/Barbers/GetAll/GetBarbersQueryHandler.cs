using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQueryHandler : IRequestHandler<GetBarbersQuery, IEnumerable<GetBarbersQueryResponse>>
    {
        private readonly IBarberRepository _barberRepository;

        public GetBarbersQueryHandler(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        public async Task<IEnumerable<GetBarbersQueryResponse>> Handle(GetBarbersQuery request, CancellationToken cancellationToken)
        {
            var barbers = await _barberRepository.GetAllBarbersAsync();

            return barbers
                .Select(barber => new GetBarbersQueryResponse
                {
                    Id = barber.Id,
                    Name = barber.User.Name,
                    About = barber.About,
                    Photo = barber.User.ImageSource,
                    Contact = barber.Contact,
                    FeedbackAverage = barber.GetFeedbackAverage(),
                    EstablishmentAddress = barber.Establishment.Address,
                });
        }
    }
}
