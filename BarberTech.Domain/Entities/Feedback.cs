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

        public Guid? EstablishmentId { get; set; }

        public Establishment? Establishment { get; set; }

        public Feedback(Guid userId, string? comment, int qntStars)
        {
            UserId = userId;
            Comment = comment;
            QntStars = qntStars;
        }

        public Feedback EvaluateHaircut(Haircut haircut)
        {
            Haircut = haircut;
            HaircutId = haircut.Id;
            return this;
        }

        public Feedback EvaluateBarber(Barber barber)
        {
            Barber = barber;
            BarberId = barber.Id;
            return this;
        }

        public Feedback EvaluateEstablishment(Establishment establishment)
        {
            Establishment = establishment;
            EstablishmentId = establishment.Id;
            return this;
        }
    }
}
