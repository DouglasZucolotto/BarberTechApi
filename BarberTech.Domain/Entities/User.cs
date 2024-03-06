using BarberTech.Domain.Entities.Enums;
using System.Collections.ObjectModel;

namespace BarberTech.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string? ImageSource { get; set; }

        public ICollection<Permission> Permissions { get; set; } = new Collection<Permission>();

        public ICollection<Feedback> Feedbacks { get; set; } = new Collection<Feedback>();

        public ICollection<EventSchedule> EventSchedules { get; set; } = new Collection<EventSchedule>();

        public Barber Barber { get; set; }

        public UserType Type { get; set; } = UserType.Client;

        public User(string email, string password, string name, string? imageSource)
        {
            Email = email;
            Password = password;
            Name = name;
            ImageSource = imageSource;
        }

        public User WithPermissions()
        {
            var permissions = GetPermissions(Type);
            Permissions = permissions.Select(permission => new Permission(this, permission)).ToList();
            return this;
        }

        private IEnumerable<string> GetPermissions(UserType type)
        {
            var common = new string[]
            {
                "users:view",
                "users:edit",
                "haircuts:view",
                "schedules:edit",
                "feedbacks:view"
            };

            if (type == UserType.Barber)
            {
                return common.Concat(new string[]
                {
                    "barbers:edit",
                });
            }

            return common.Concat(new string[]
            {
                "establishments:view",
                "feedbacks:edit"
            });
        }
    }
}
