using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetById
{
    public class GetEstablishmentByIdQueryHandler : IRequestHandler<GetEstablishmentByIdQuery, GetEstablishmentByIdQueryResponse?>
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly INotificationContext _notification;

        public GetEstablishmentByIdQueryHandler(IEstablishmentRepository establishmentRepository, INotificationContext notification)
        {
            _establishmentRepository = establishmentRepository;
            _notification = notification;
        }

        public async Task<GetEstablishmentByIdQueryResponse?> Handle(GetEstablishmentByIdQuery request, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetByIdWithFeedbacksAsync(request.Id);

            if (establishment is null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            return new GetEstablishmentByIdQueryResponse
            {
                Id = establishment.Id,
                Address = establishment.Address,
                ImageSource = establishment.ImageSource,
                Latitude = establishment.Coordinates.Y,
                Longitude = establishment.Coordinates.X,
                BusinessTime = establishment.GetBusinessTime(),
                QntStars = establishment.GetFeedbacksAverage(),
            };
        }
    }
}

