using MediatR;
using NetTopologySuite.Geometries;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Address { get; set; }

        public Point Coordinates { get; set; }

        public string ImageSource { get; set; }

        public string? Description { get; set; }

        public string BusinessHours { get; set; }

        public UpdateEstablishmentCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
