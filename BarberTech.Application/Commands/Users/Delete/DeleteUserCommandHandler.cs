using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Users.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Nothing>
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationContext _notification;

        public DeleteUserCommandHandler(IUserRepository userRepository, INotificationContext notification)
        {
            _userRepository = userRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdToDeleteAsync(request.Id);

            if (user is null)
            {
                _notification.AddNotFound("User does not exists");
                return default;
            }

            _userRepository.Remove(user);
            await _userRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
