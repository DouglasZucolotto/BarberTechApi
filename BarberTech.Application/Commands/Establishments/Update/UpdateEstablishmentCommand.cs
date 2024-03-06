using BarberTech.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string? Address { get; set; }

        public string? ImageSource { get; set; }

        public string? OpenTime { get; set; }

        public string? LunchTime { get; set; }

        public string? WorkInterval { get; set; }

        public string? LunchInterval { get; set; }

        public UpdateEstablishmentCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
