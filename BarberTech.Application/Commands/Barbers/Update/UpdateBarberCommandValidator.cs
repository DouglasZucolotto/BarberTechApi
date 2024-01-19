using FluentValidation;

namespace BarberTech.Application.Commands.Barbers.Update
{
    public class UpdateBarberCommandValidator : AbstractValidator<UpdateBarberCommand>
    {
        public UpdateBarberCommandValidator()
        {
        }
    }
}
