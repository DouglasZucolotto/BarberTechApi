namespace BarberTech.Infraestructure.Entities
{
    public class Permission
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }
    }
}
