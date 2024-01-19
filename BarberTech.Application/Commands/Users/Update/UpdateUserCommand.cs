using BarberTech.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Users.Update
{
    public class UpdateUserCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? ImageSource { get; set; }

        public UpdateUserCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
