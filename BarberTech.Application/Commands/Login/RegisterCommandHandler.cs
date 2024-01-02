using BarberTech.Infraestructure;
using BarberTech.Infraestructure.Authentication;
using BarberTech.Infraestructure.Entities;
using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Nothing>
    {
        private readonly DataContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(DataContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<Nothing> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userExists = _context.Users.Any(u => u.Email == request.Email);

            if (userExists)
            {
                // TODO: notificator / Usuário já cadastrado
                return default;
            }

            var hashedPassword = _passwordHasher.Generate(request.Password);
            
            var user = new User(request.Email, hashedPassword, request.Name, request.ImageSource);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
