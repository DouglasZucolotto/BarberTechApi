using BarberTech.Application.Queries.Barbers.Dtos;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQueryHandler : IRequestHandler<GetBarbersQuery, PagedResponse<GetBarbersQueryResponse>>
    {
        private readonly IBarberRepository _barberRepository;

        public GetBarbersQueryHandler(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        public async Task<PagedResponse<GetBarbersQueryResponse>> Handle(GetBarbersQuery request, CancellationToken cancellationToken)
        {
            var queryResponse = await _barberRepository.GetAllBarbersPagedAsync(request.Page, request.PageSize);

            var barbers = queryResponse.Barbers
                .Select(barber => new GetBarbersQueryResponse
                {
                    Id = barber.Id,
                    Name = barber.User.Name,
                    About = barber.About,
                    ImageSource = barber.User.ImageSource,
                    Contact = barber.Contact,
                    Rating = barber.GetFeedbacksAverage(),
                    EstablishmentAddress = barber.Establishment.Address,
                    EventSchedules = barber.EventSchedules.Select(es => new EventScheduleDto
                    {
                        Id = es.Id,
                        Name = es.Name,
                        DateTime = es.DateTime,
                        Status = es.EventStatus.ToString(),
                    })
                });

            return new PagedResponse<GetBarbersQueryResponse>(
                barbers,
                request.Page, 
                request.PageSize, 
                queryResponse.Count);
        }
    }
}
