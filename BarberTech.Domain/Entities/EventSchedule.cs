using BarberTech.Domain.Entities.Enums;

namespace BarberTech.Domain.Entities
{
    public class EventSchedule : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }
     
        public Guid BarberId { get; set; }

        public Barber Barber { get; set; }

        public Guid HaircutId { get; set; }

        public Haircut Haircut { get; set; }

        public string Name { get; set; }
        
        public DateTime DateTime { get; set; }

        public EventStatus EventStatus { get; set; }

        public EventSchedule()
        {
        }

        public EventSchedule(User user, Barber barber, Haircut haircut, string name, DateTime dateTime)
        {
            User = user;
            UserId = user.Id;
            Barber = barber;
            BarberId = barber.Id;
            Haircut = haircut;
            HaircutId = haircut.Id;
            Name = name;
            DateTime = dateTime;
            EventStatus = EventStatus.Active;
        }
    }
}
