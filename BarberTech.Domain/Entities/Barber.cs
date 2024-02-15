using BarberTech.Domain.Entities.Enums;

namespace BarberTech.Domain.Entities
{
    public class Barber : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string? About { get; set; }

        public string Contact { get; set; }

        public string ImageSource { get; set; }

        public Guid EstablishmentId { get; set; }

        public Establishment Establishment { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<EventSchedule> EventSchedules { get; set; }

        public Barber(
            Establishment establishment,
            Guid userId,
            string contact, 
            string? about, 
            string imageSource)
        {
            UserId = userId;
            Establishment = establishment;
            Contact = contact;
            About = about;
            ImageSource = imageSource;
        }

        public Barber()
        {
        }

        public double GetFeedbacksAverage()
        {
            if (Feedbacks.Count == 0)
            {
                return 0;
            }

            return Feedbacks.Average(f => f.QntStarsBarber);
        }

        public IEnumerable<TimeSpan> GetAvailableTimesByDateTime(DateTime dateTime)
        {
            var eventTimes = EventSchedules
                .Where(es => es.DateTime.Date == dateTime.Date && es.EventStatus == EventStatus.Active)
                .Select(es => es.DateTime.ToLocalTime());

            var closeTime = Establishment.OpenTime.Add(Establishment.WorkInterval + Establishment.LunchInterval);
            var availableTimes = new List<TimeSpan>();

            for (var time = Establishment.OpenTime; time < closeTime; time += TimeSpan.FromMinutes(30))
            {
                var isLunchInterval = time >= Establishment.LunchTime && time < Establishment.LunchTime.Add(Establishment.LunchInterval);
                var anyEvent = eventTimes.Any(e => e.TimeOfDay == time);

                if (!anyEvent && !isLunchInterval)
                {
                    availableTimes.Add(time);
                }
            }

            return availableTimes;
        }
    }
}
