using BarberTech.Application.Queries.Barbers.Dtos;
using BarberTech.Domain;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQueryHandler : IRequestHandler<GetBarbersQuery, Paged<GetBarbersQueryResponse>>
    {
        private readonly IBarberRepository _barberRepository;

        public GetBarbersQueryHandler(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        public async Task<Paged<GetBarbersQueryResponse>> Handle(GetBarbersQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "User", "Name", "Contact", "Instagram", "Facebook", "Twitter" };

            var (items, totalCount) = await _barberRepository.GetAllPagedAsync(
                request.Page,
                request.PageSize,
                request.SearchTerm,
                filterProps);

            var barbers = items
                .Select(barber => new GetBarbersQueryResponse
                {
                    Id = barber.Id,
                    Name = barber.User.Name,
                    Contact = barber.Contact,
                    About = barber.About,
                    ImageSource = barber.User.ImageSource,
                    Rating = barber.GetRating(),
                    Social = new SocialDto
                    {
                        Facebook = barber.Facebook,
                        Instagram = barber.Instagram,
                        Twitter = barber.Twitter,
                    },
                })
                .OrderByDescending(barber => barber.Rating);

            return new Paged<GetBarbersQueryResponse>(barbers, request.Page, request.PageSize, totalCount);
        }
    }
}
