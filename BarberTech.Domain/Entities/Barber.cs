namespace BarberTech.Domain.Entities
{
    public class Barber : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string? About { get; set; }

        public string Contact { get; set; }

        public Guid EstablishmentId { get; set; }

        public Establishment Establishment { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public double GetFeedbackAverage()
        {
            if (Feedbacks.Count == 0)
            {
                return 0;
            }

            double allStars = Feedbacks.Sum(f => f.QntStars);
            var average = allStars / Feedbacks.Count;

            return Math.Round(average, 2);
        }

        public Barber(Guid userId, Establishment establishment, string contact, string? about)
        {
            UserId = userId;
            Establishment = establishment;
            Contact = contact;
            About = about;
        }

        public Barber()
        {
        }
    }
}
