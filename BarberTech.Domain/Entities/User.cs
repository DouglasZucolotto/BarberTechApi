namespace BarberTech.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public ICollection<Permission> Permissions { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<EventSchedule> EventSchedules { get; set; }

        public Barber Barber { get; set; }

        public User(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }

        public void RemovePermissions()
        {
            foreach (var permission in Permissions.ToList())
            {
                Permissions.Remove(permission);
            }
        }
    }
}
