using BarberTech.Application.Commands.Barbers.Dtos;
using BarberTech.Domain;
using BarberTech.Domain.Authentication;
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
        private readonly IPasswordHasher _passwordHasher;

        public CreateBarberCommandHandler(
            IBarberRepository barberRepository, 
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IEstablishmentRepository establishmentRepository, 
            INotificationContext notification)
        {
            _barberRepository = barberRepository;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _establishmentRepository = establishmentRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(CreateBarberCommand request, CancellationToken cancellationToken)
        {
            var emailExists = await _userRepository.UserEmailExistsAsync(request.Email);

            if (emailExists)
            {
                _notification.AddBadRequest("Email already registered.");
                return default;
            }

            var establishment = await _establishmentRepository.GetByIdAsync(request.EstablishmentId);

            if (establishment == null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            var hashedPassword = _passwordHasher.Generate(request.Password);

            var user = new User(request.Email, hashedPassword, request.Name, request.ImageSource)
                .WithType(UserType.Barber)
                .WithPermissions();

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
