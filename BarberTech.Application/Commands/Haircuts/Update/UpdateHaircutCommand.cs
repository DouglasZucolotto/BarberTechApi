using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Haircuts.Update
{
    public class UpdateHaircutCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ImageSource { get; set; }

        public UpdateHaircutCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
