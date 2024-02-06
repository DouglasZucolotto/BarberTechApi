﻿using NetTopologySuite.Geometries;

namespace BarberTech.Domain.Entities
{
    public class Establishment : Entity
    {
        public string Address { get; set; }

        public Point Coordinates { get; set; }

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

        public double GetFeedbacksAverage()
        {
            if (Feedbacks.Count == 0)
            {
                return 0;
            }

            return Feedbacks.Average(f => f.QntStars);
        }

        public Establishment()
        {
        }

        public Establishment(
            string address, 
            Point coordinates, 
            TimeSpan openTime,
            TimeSpan lunchTime,
            TimeSpan workInterval,
            TimeSpan lunchInterval)
        {
            Address = address;
            Coordinates = coordinates;
            OpenTime = openTime;
            LunchTime = lunchTime;
            WorkInterval = workInterval;
            LunchInterval = lunchInterval;
        }
    }
}
