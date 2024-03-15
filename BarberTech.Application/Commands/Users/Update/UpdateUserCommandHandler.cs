using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Nothing>
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationContext _notification;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, INotificationContext notification)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _notification = notification;
        }

        public async Task<Nothing> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                _notification.AddNotFound("User does not exists");
                return default;
            }

            user.Name = request.Name ?? user.Name;
            user.Email = request.Email ?? user.Email;
            user.ImageSource = request.ImageSource ?? user.ImageSource;

            if (request.Password != null)
            {
                user.Password = _passwordHasher.Generate(request.Password);
            }

            _userRepository.Update(user);
            await _userRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
