using NetTopologySuite.Geometries;

namespace BarberTech.Domain.Entities
{
    public class Establishment : Entity
    {
        public string Address { get; set; }

        public Point Coordinates { get; set; }

        public string ImageSource { get; set; }

        public string? Description { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

        public ICollection<Barber> Barbers { get; set; } = new List<Barber>();

        public ICollection<EventSchedule> EventSchedules { get; set; } = new List<EventSchedule>();

        public TimeSpan OpenTime { get; set; }

        public TimeSpan LunchTime { get; set; }

        public TimeSpan WorkInterval { get; set; }

        public TimeSpan LunchInterval { get; set; }

        public string GetBusinessTime()
        {
            return $"{OpenTime} ~ {OpenTime.Add(WorkInterval).Add(LunchInterval)}";
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
            TimeSpan lunchInterval,
            string? description)
        {
            Address = address;
            Coordinates = coordinates;
            ImageSource = imageSource;
            Description = description;
            OpenTime = openTime;
            LunchTime = lunchTime;
            WorkInterval = workInterval;
            LunchInterval = lunchInterval;
        }
    }
}
