namespace BarberTech.Domain.Entities
{
    public class Feedback : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string? Comment { get; set; }

        public int QntStars { get; set; }

        public Guid? HaircutId { get; set; }

        public Haircut? Haircut { get; set; }

        public Guid? BarberId { get; set; }

        public Barber? Barber { get; set; }

        public Feedback(Guid userId, string? comment, int qntStars)
        {
            UserId = userId;
            Comment = comment;
            QntStars = qntStars;
        }

        public Feedback EvaluateHaircut(Guid haircutId)
        {
            HaircutId = haircutId;
            return this;
        }

        public Feedback EvaluateBarber(Guid barberId)
        {
            BarberId = barberId;
            return this;
        }
    }
}
