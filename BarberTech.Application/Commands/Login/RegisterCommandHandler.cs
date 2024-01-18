﻿using BarberTech.Domain;
using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Nothing>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly INotificationContext _notification;

        public RegisterCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, INotificationContext notification)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _notification = notification;
        }

        public async Task<Nothing> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var emailExists = await _userRepository.UserEmailExistsAsync(request.Email);

            if (emailExists)
            {
                _notification.AddBadRequest("Email already registered");
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
