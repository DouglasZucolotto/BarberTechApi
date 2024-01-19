using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Users.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Nothing>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPermissionRepository _permissionRepository;
        private readonly INotificationContext _notification;

        public DeleteUserCommandHandler(IUserRepository userRepository, INotificationContext notification, IPermissionRepository permissionRepository)
        {
            _userRepository = userRepository;
            _notification = notification;
            _permissionRepository = permissionRepository;
        }

        public async Task<Nothing> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetWithPermissionsAsync(request.Id);

            if (user is null)
            {
                _notification.AddNotFound("User does not exists");
                return default;
            }

            user.RemovePermissions();

            _userRepository.Remove(user);
            await _userRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
