using BarberTech.Application.Commands.Users.Dtos;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly INotificationContext _notification;
        private readonly IJwtProvider _jwtProvider;

        public RegisterUserCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher, 
            INotificationContext notification,
            IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _notification = notification;
            _jwtProvider = jwtProvider;
        }

        public async Task<RegisterUserCommandResponse?> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var emailExists = await _userRepository.UserEmailExistsAsync(request.Email);

            if (emailExists)
            {
                _notification.AddBadRequest("Email already registered.");
                return default;
            }

            var hashedPassword = _passwordHasher.Generate(request.Password);

            var user = new User(request.Email, hashedPassword, request.Name, request.ImageSource)
                .WithPermissions();

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.CommitAsync();

            var token = _jwtProvider.Generate(user);

            return new RegisterUserCommandResponse()
            {
                Token = token,
                User = new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Type = user.Type.ToString(),
                    ImageSource = user.ImageSource,
                }
            };
        }
    }
}
