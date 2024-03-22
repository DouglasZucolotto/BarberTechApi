using BarberTech.Application.Queries.Barbers.Dtos;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Barbers.GetById
{
    public class GetBarberByIdQueryHandler : IRequestHandler<GetBarberByIdQuery, GetBarberByIdQueryResponse?>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly INotificationContext _notification;

        public GetBarberByIdQueryHandler(IBarberRepository barberRepository, INotificationContext notification)
        {
            _barberRepository = barberRepository;
            _notification = notification;
        }

        public async Task<GetBarberByIdQueryResponse?> Handle(GetBarberByIdQuery request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetByIdAsync(request.Id);

            if (barber is null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            return new GetBarberByIdQueryResponse
            {
                Id = barber.Id,
                About = barber.About,
                Contact = barber.Contact,
                EstablishmentId = barber.EstablishmentId,
                ImageSource = barber.User.ImageSource,
                Social = new SocialDto
                {
                    Facebook = barber.Facebook,
                    Instagram = barber.Instagram,
                    Twitter = barber.Twitter,
                },
            };
        }
    }
}

