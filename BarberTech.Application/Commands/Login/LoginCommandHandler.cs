using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                // TODO: notificator / Invalid Credentials
                return default;
            }

            var validPassword = _passwordHasher.Verify(user.Password, request.Password);

            if (!validPassword)
            {
                // TODO: notificator / Invalid Credentials
                return default;
            }

            return _jwtProvider.Generate(user);
        }
    }
}
