namespace BarberTech.Domain.Entities
{
    public class Barber : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
