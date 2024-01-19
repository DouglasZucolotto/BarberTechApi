using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Create
{
    public class CreateBarberCommand : IRequest<Nothing>
    {
        public Guid EstablishmentId { get; set; }

        public string? About { get; set; }

        public string Contact { get; set; } = string.Empty;
    }
}
