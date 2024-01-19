using BarberTech.Application.Commands.Haircuts.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberTech.Application.Commands.Users.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty();
        }
    }
}
