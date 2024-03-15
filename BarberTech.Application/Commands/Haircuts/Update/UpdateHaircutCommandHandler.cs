using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Update
{
    public class UpdateHaircutCommandHandler : IRequestHandler<UpdateHaircutCommand, Nothing>
    {
        private readonly IHaircutRepository _haircutRepository;
        private readonly INotificationContext _notification;

        public UpdateHaircutCommandHandler(IHaircutRepository haircutRepository, INotificationContext notification)
        {
            _haircutRepository = haircutRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(UpdateHaircutCommand request, CancellationToken cancellationToken)
        {
            var haircut = await _haircutRepository.GetByIdAsync(request.Id);

            if (haircut is null)
            {
                _notification.AddNotFound("Haircut does not exists");
                return default;
            }

            haircut.Name = request.Name ?? haircut.Name;
            haircut.About = request.About ?? haircut.About;
            haircut.Price = request.Price ?? haircut.Price;
            haircut.ImageSource = request.ImageSource ?? haircut.ImageSource;

            _haircutRepository.Update(haircut);
            await _haircutRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
