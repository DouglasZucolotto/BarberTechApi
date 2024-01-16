using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Create
{
    public class CreateBarberCommandHandler : IRequestHandler<CreateBarberCommand, Nothing>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly INotificationContext _notification;
        private readonly IHttpContext _httpContext;

        public CreateBarberCommandHandler(
            IBarberRepository barberRepository, 
            IEstablishmentRepository establishmentRepository, 
            INotificationContext notification,
            IHttpContext httpContext)
        {
            _barberRepository = barberRepository;
            _establishmentRepository = establishmentRepository;
            _notification = notification;
            _httpContext = httpContext;
        }

        public async Task<Nothing> Handle(CreateBarberCommand request, CancellationToken cancellationToken)
        {
            // TODO: verificar se o usuário existe pra todos / talvez fazer isso dentro do método
            var userId = _httpContext.GetUserId();

            var establishment = await _establishmentRepository.GetByIdAsync(request.EstablishmentId);

            if (establishment == null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            var barber = new Barber(userId, establishment, request.Contact, request.About);

            _barberRepository.Add(barber);
            await _barberRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
