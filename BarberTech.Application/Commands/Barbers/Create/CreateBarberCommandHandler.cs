using BarberTech.Domain;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Entities.Enums;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Create
{
    public class CreateBarberCommandHandler : IRequestHandler<CreateBarberCommand, Nothing>
    {
        private readonly IBarberRepository _barberRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly INotificationContext _notification;

        public CreateBarberCommandHandler(
            IBarberRepository barberRepository, 
            IUserRepository userRepository,
            IEstablishmentRepository establishmentRepository, 
            INotificationContext notification)
        {
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _establishmentRepository = establishmentRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(CreateBarberCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                _notification.AddNotFound("User does not exists");
                return default;
            }

            user.Type = UserType.Barber;

            var establishment = await _establishmentRepository.GetByIdAsync(request.EstablishmentId);

            if (establishment == null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            var barber = new Barber(
                establishment, 
                user, 
                request.Contact, 
                request.About,
                request.Social.Facebook,
                request.Social.Instagram,
                request.Social.Twitter);

            _barberRepository.Add(barber);
            await _barberRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
