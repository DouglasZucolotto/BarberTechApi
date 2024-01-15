using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Delete
{
    public class DeleteHaircutCommandHandler : IRequestHandler<DeleteHaircutCommand, Nothing>
    {
        private readonly IHaircutRepository _haircutRepository;
        private readonly INotificationContext _notification;

        public DeleteHaircutCommandHandler(IHaircutRepository haircutRepository, INotificationContext notification)
        {
            _haircutRepository = haircutRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(DeleteHaircutCommand request, CancellationToken cancellationToken)
        {
            var haircut = await _haircutRepository.GetByIdAsync(request.Id);

            if (haircut is null)
            {
                _notification.AddNotFound("Haircut does not exists");
                return default;
            }

            _haircutRepository.Remove(haircut);
            await _haircutRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
