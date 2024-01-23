namespace BarberTech.Domain.Entities
{
    public class EventSchedule : Entity
    {
        public Guid UserId { get; set; }

        public User User { get; set; }
     
        public Guid BarberId { get; set; }

        public Barber Barber { get; set; }

        public string Name { get; set; }

        public Guid EstablishmentId { get; set; }

        public Establishment Establishment { get; set; }

        public DateTime DateTime { get; set; }

        public EventSchedule(Guid userId, Guid barberId, string name, Guid establishmentId, DateTime dateTime)
        {
            UserId = userId;
            BarberId = barberId;
            Name = name;
            EstablishmentId = establishmentId;
            DateTime = dateTime;
        }
    }
}
