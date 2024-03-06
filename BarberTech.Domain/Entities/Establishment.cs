using NetTopologySuite.Geometries;

namespace BarberTech.Domain.Entities
{
    public class Establishment : Entity
    {
        public string Address { get; set; }

        public string ImageSource { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

        public ICollection<Barber> Barbers { get; set; } = new List<Barber>();

        public TimeSpan OpenTime { get; set; }

        public TimeSpan LunchTime { get; set; }

        public TimeSpan WorkInterval { get; set; }

        public TimeSpan LunchInterval { get; set; }

        public string GetBusinessTime()
        {
            return $"{OpenTime} ~ {OpenTime.Add(WorkInterval).Add(LunchInterval)}";
        }

        public double GetRating()
        {
            if (Feedbacks.Count == 0)
            {
                return 0;
            }

            var average = Feedbacks.Average(f => f.RatingEstablishment);

            return Math.Round(average, 1);
        }

        public Establishment()
        {
        }

        public Establishment(
            string address,
            string imageSource,
            TimeSpan openTime,
            TimeSpan lunchTime,
            TimeSpan workInterval,
            TimeSpan lunchInterval)
        {
            Address = address;
            ImageSource = imageSource;
            OpenTime = openTime;
            LunchTime = lunchTime;
            WorkInterval = workInterval;
            LunchInterval = lunchInterval;
        }
    }
}
