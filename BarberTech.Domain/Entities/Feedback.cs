namespace BarberTech.Domain.Entities
{
    public class Feedback : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid HaircutId { get; set; }

        public Haircut Haircut { get; set; }

        public Guid BarberId { get; set; }

        public Barber Barber { get; set; }

        public Guid EstablishmentId { get; set; }

        public Establishment Establishment { get; set; }

        public EventSchedule EventSchedule { get; set; }

        public int RatingBarber { get; set; }

        public int RatingHaircut { get; set; }

        public int RatingEstablishment { get; set; }

        public string? Comment { get; set; }

        public Feedback(
            User user, 
            Barber barber,
            Haircut haircut,
            Establishment establishment,
            int ratingBarber,
            int ratingHaircut,
            int ratingEstablishment,
            string? comment)
        {
            User = user;
            UserId = user.Id;
            Barber= barber;
            BarberId = barber.Id;
            Haircut= haircut;
            HaircutId = haircut.Id;
            Establishment= establishment;
            EstablishmentId = establishment.Id;
            RatingBarber = ratingBarber;
            RatingHaircut = ratingHaircut;
            RatingEstablishment = ratingEstablishment;
            Comment = comment;
        }

        public Feedback()
        {
        }

        public double GetRatingAverage()
        {
            double sum = RatingBarber + RatingHaircut + RatingEstablishment;
            double average = sum / 3;
            return Math.Round(average, 1);
        }
    }
}
