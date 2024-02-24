using NetTopologySuite.Geometries;

namespace BarberTech.Domain.Entities
{
    public class Establishment : Entity
    {
        public string Address { get; set; }

        public Point Coordinates { get; set; }

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

            return Feedbacks.Average(f => f.RatingEstablishment);
        }

        public Establishment()
        {
        }

        public Establishment(
            string address, 
            Point coordinates,
            string imageSource,
            TimeSpan openTime,
            TimeSpan lunchTime,
            TimeSpan workInterval,
            TimeSpan lunchInterval)
        {
            Address = address;
            Coordinates = coordinates;
            ImageSource = imageSource;
            OpenTime = openTime;
            LunchTime = lunchTime;
            WorkInterval = workInterval;
            LunchInterval = lunchInterval;
        }
    }
}
