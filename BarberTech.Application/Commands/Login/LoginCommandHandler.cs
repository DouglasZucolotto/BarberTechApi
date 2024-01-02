using BarberTech.Infraestructure;
using BarberTech.Infraestructure.Authentication;
using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly DataContext _context;
        private readonly IJwtProvider _jwtProvider;
        private readonly IPasswordHasher _passwordHasher;

        public LoginCommandHandler(DataContext context, IJwtProvider jwtProvider, IPasswordHasher passwordHasher)
        {
            _context = context;
            _jwtProvider = jwtProvider;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user == null)
            {
                // TODO: notificator / Invalid Credentials
                return default;
            }

            var validPassword = _passwordHasher.Verify(user.Password, request.Password);

            if(!validPassword)
            {
                // TODO: notificator / Invalid Credentials
                return default;
            }

            return _jwtProvider.Generate(user);
        }
    }
}
