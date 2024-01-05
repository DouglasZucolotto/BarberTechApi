namespace BarberTech.Domain.Entities
{
    public class User : Entity
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string ImageSource { get; set; }

        public ICollection<Permission> Permissions { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public Barber Barber { get; set; }

        public User(string email, string password, string name, string imageSource)
        {
            Email = email;
            Password = password;
            Name = name;
            ImageSource = imageSource;
        }
    }
}
