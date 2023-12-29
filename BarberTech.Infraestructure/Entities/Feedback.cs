namespace BarberTech.Infraestructure.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        public Guid UserId => User.Id;

        public string? Comment { get; set; }

        public int QntStars { get; set; }

        public Haircut? Haircut { get; set; }

        public Guid? HaircutId => Haircut?.Id;

        //public Barber? Barber { get; set; }

        //public Guid? BarberId => Barber?.Id;

        public Feedback()
        {
        }

        public Feedback(User user, string? comment, int qntStars)
        {
            User = user;
            Comment = comment;
            QntStars = qntStars;
        }

        public Feedback EvaluateHaircut(Haircut haircut)
        {
            Haircut = haircut;
            return this;
        }

        //public Feedback EvaluateBarber(Barber barber)
        //{
        //    Barber = barber;
        //    return this;
        //}
    }
}
