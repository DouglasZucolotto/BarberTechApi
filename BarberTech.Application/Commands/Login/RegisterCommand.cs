﻿using MediatR;

namespace BarberTech.Application.Commands.Login
{
    public class RegisterCommand : IRequest<Nothing>
    {
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? ImageSource { get; set; }
    }
}
