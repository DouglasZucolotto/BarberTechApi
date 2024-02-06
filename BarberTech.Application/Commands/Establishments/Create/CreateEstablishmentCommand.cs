using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Establishments.Create
{
    public class CreateEstablishmentCommand : IRequest<Nothing>
    {
        public string Address { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string OpenTime { get; set; } = string.Empty;

        public string LunchTime { get; set; } = string.Empty;

        public string WorkInterval { get; set; } = string.Empty;

        public string LunchInterval { get; set; } = string.Empty;
    }
}
