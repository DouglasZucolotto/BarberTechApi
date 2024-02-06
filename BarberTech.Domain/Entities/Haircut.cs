namespace BarberTech.Domain.Entities
{
    public class Haircut : Entity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public string ImageSource { get; set; }

        public decimal Price { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public Haircut(string name, string? description, string imageSource, decimal price)
        {
            Name = name;
            Description = description;
            ImageSource = imageSource;
            Price = price;
        }

        public double GetFeedbacksAverage()
        {
            if (Feedbacks.Count == 0) 
            { 
                return 0; 
            }
            return Feedbacks.Average(f => f.QntStars);
        }
    }
}
