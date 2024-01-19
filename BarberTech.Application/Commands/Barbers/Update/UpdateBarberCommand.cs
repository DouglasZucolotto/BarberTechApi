using BarberTech.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Barbers.Update
{
    public class UpdateBarberCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public Guid? EstablishmentId { get; set; }

        public string? About { get; set; }

        public string? Contact { get; set; }

        public UpdateBarberCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
