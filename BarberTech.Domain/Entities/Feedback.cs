namespace BarberTech.Domain.Entities
{
    public class Feedback : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string? Comment { get; set; }

        public int QntStars { get; set; }

        public Guid HaircutId { get; set; }

        public Haircut Haircut { get; set; }

        public Guid BarberId { get; set; }

        public Barber Barber { get; set; }

        public Guid EstablishmentId { get; set; }

        public Establishment Establishment { get; set; }

        public Feedback(
            Guid userId, 
            string? comment, 
            int qtdStars, 
            Guid establishmentId, 
            Guid haircutId, 
            Guid barberId)
        {
            UserId = userId;
            Comment = comment;
            QntStars = qtdStars;
            EstablishmentId = establishmentId;
            HaircutId = haircutId;
            BarberId = barberId;
        }

        public Feedback()
        {
        }
    }
}
