namespace BarberTech.Domain.Entities
{
    public class EventSchedule : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }
     
        public Guid BarberId { get; set; }

        public Barber Barber { get; set; }

        public string Name { get; set; }
        
        public DateTime DateTime { get; set; }

        public EventSchedule()
        {
        }

        public EventSchedule(User user, Barber barber, string name, DateTime dateTime)
        {
            User = user;
            UserId = user.Id;
            Barber = barber;
            BarberId = barber.Id;
            Name = name;
            DateTime = dateTime;
        }
    }
}
