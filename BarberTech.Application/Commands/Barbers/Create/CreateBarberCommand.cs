using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Create
{
    public class CreateBarberCommand : IRequest<Nothing>
    {
        public Guid EstablishmentId { get; set; }

        public string? About { get; set; }

        public string Contact { get; set; } = string.Empty;

        public string? ImageSource { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
    }
}
