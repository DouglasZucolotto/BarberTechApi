namespace BarberTech.Domain.Entities
{
    public class Haircut : Entity
    {
        public string Name { get; set; }

        public string? About { get; set; }

        public string ImageSource { get; set; }

        public decimal Price { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<EventSchedule> EventSchedules { get; set; }

        public Haircut(string name, string? about, string imageSource, decimal price)
        {
            Name = name;
            About = about;
            ImageSource = imageSource;
            Price = price;
        }

        public double GetFeedbacksAverage()
        {
            if (Feedbacks.Count == 0) 
            { 
                return 0; 
            }

            return Feedbacks.Average(f => f.RatingHaircut);
        }
    }
}
