using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQueryHandler : IRequestHandler<GetHaircutByIdQuery, GetHaircutByIdQueryResponse?>
    {
        private readonly IHaircutRepository _haircutRepository;
        private readonly INotificationContext _notification;

        public GetHaircutByIdQueryHandler(IHaircutRepository haircutRepository, INotificationContext notification)
        {
            _haircutRepository = haircutRepository;
            _notification = notification;
        }

        public async Task<GetHaircutByIdQueryResponse?> Handle(GetHaircutByIdQuery request, CancellationToken cancellationToken)
        {
            var haircut = await _haircutRepository.GetByIdAsync(request.Id);

            if (haircut is null)
            {
                _notification.AddNotFound("Haircut does not exists");
                return default;
            }

            return new GetHaircutByIdQueryResponse
            {
                Id = haircut.Id,
                Name = haircut.Name,
                About = haircut.About,
                ImageSource = haircut.ImageSource,
                Price = haircut.Price,
            };
        }
    }
}
