using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ImageSource { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string BusinessHours { get; set; } = string.Empty;

        public UpdateEstablishmentCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
