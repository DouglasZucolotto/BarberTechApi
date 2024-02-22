using BarberTech.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Users.Update
{
    public class UpdateUserCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Name { get; set; }

        public string? ImageSource { get; set; }

        public UpdateUserCommand(string? email, string? password, string? name, string? imageSource)
        {
            Email = email;
            Password = password;
            Name = name;
            ImageSource = imageSource;
        }

        public UpdateUserCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
