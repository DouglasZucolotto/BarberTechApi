using BarberTech.Application.Commands.Barbers.Dtos;
using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Create
{
    public class CreateBarberCommand : IRequest<Nothing>
    {
        public Guid EstablishmentId { get; set; }

        public Guid UserId { get; set; }

        public string? About { get; set; }

        public SocialDto Social { get; set; } = new SocialDto();

        public string Contact { get; set; } = string.Empty;

        public string ImageSource { get; set; } = string.Empty;
    }
}
