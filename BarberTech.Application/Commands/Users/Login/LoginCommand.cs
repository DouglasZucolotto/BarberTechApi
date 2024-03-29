﻿using MediatR;

namespace BarberTech.Application.Commands.Users.Login
{
    public class LoginCommand : IRequest<LoginCommandResponse?>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
