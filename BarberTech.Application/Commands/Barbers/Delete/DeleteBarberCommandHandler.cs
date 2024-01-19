using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Delete
{
    public class DeleteBarberCommandHandler : IRequestHandler<DeleteBarberCommand, Nothing>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly INotificationContext _notification;

        public DeleteBarberCommandHandler(IBarberRepository barberRepository, INotificationContext notification)
        {
            _barberRepository = barberRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(DeleteBarberCommand request, CancellationToken cancellationToken)
        {
            var barber = await _barberRepository.GetByIdAsync(request.Id);

            if (barber is null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            _barberRepository.Remove(barber);
            await _barberRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
