using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Nothing>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Nothing> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var emailExists = await _userRepository.UserEmailExistsAsync(request.Email);

            if (emailExists)
            {
                // TODO: notificator / Usuário já cadastrado
                return default;
            }

            var hashedPassword = _passwordHasher.Generate(request.Password);
            
            var user = new User(request.Email, hashedPassword, request.Name, request.ImageSource);

            _userRepository.Add(user);
            await _userRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
