using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;
        private readonly INotificationContext _notification;

        public LoginCommandHandler(
            IUserRepository userRepository, 
            IJwtProvider jwtProvider, 
            IPasswordHasher passwordHasher,
            INotificationContext notification)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
            _notification = notification;
        }

        public async Task<string?> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                _notification.AddUnauthorized("Invalid Credentials");
                return default;
            }

            var validPassword = _passwordHasher.Verify(user.Password, request.Password);

            if (!validPassword)
            {
                _notification.AddUnauthorized("Invalid Credentials");
                return default;
            }

            return _jwtProvider.Generate(user);
        }
    }
}
