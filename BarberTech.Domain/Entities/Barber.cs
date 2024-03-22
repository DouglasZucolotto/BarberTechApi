using BarberTech.Domain.Entities.Enums;

namespace BarberTech.Domain.Entities
{
    public class Barber : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string? About { get; set; }

        public string Contact { get; set; }

        public Guid? EstablishmentId { get; set; }

        public Establishment? Establishment { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<EventSchedule> EventSchedules { get; set; }

        public string? Facebook { get; set; }

        public string? Instagram { get; set; }

        public string? Twitter { get; set; }

        public Barber(
            Establishment establishment,
            User user,
            string contact,
            string? about,
            string? facebook,
            string? intagram,
            string? twitter)
        {
            User = user;
            UserId = user.Id;
            Establishment = establishment;
            Contact = contact;
            About = about;
            Facebook = facebook;
            Instagram = intagram;
            Twitter = twitter;
        }

        public Barber()
        {
        }

        public double GetRating()
        {
            if (Feedbacks.Count == 0)
            {
                return 0;
            }

            var average = Feedbacks.Average(f => f.RatingBarber);

            return Math.Round(average, 1);
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

        public Dictionary<string, Dictionary<string, EventSchedule?>> GetCalendar()
        {
            var today = DateTime.Today;
            var twoWeeks = today.AddDays(14);
            var calendar = new Dictionary<string, Dictionary<string, EventSchedule?>>();
            
            var activeTimes = EventSchedules
                .Where(es => es.EventStatus == EventStatus.Active && es.DateTime >= today);

            for (var day = today; day < twoWeeks; day = day.AddDays(1))
            {
                var closeTime = Establishment.OpenTime.Add(Establishment.WorkInterval + Establishment.LunchInterval);
                var dayEvents = new Dictionary<string, EventSchedule?>();

                for (var time = Establishment.OpenTime; time < closeTime; time += TimeSpan.FromMinutes(30))
                {
                    var dateTime = new DateTime(day.Year, day.Month, day.Day, time.Hours, time.Minutes, 0);
                    var eventSchedule = activeTimes.FirstOrDefault(e => e.DateTime == dateTime);
                    var convertedTime = dateTime.ToString("HH:mm");
                    dayEvents.Add(convertedTime, eventSchedule);
                }
                var convertedDay = day.ToString("dd/MM/yyyy");
                calendar.Add(convertedDay, dayEvents);
            }
            return calendar;
        }
    }
}
