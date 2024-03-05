using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Establishments.Delete
{
    public class DeleteEstablishmentCommandHandler : IRequestHandler<DeleteEstablishmentCommand, Nothing>
    {
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly INotificationContext _notification;

        public DeleteEstablishmentCommandHandler(IEstablishmentRepository establishmentRepository, INotificationContext notification)
        {
            _establishmentRepository = establishmentRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(DeleteEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishment = await _establishmentRepository.GetByIdToDeleteAsync(request.Id);

            if (establishment is null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            foreach(var barber in establishment.Barbers)
            {
                barber.Establishment = null;
                barber.EstablishmentId = null;
            }

            _establishmentRepository.Remove(establishment);
            await _establishmentRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
