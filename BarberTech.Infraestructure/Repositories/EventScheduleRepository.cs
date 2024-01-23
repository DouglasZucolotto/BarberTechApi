using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;

namespace BarberTech.Infraestructure.Repositories
{
    public class EventScheduleRepository : Repository<EventSchedule>, IEventScheduleRepository
    {
        public EventScheduleRepository(DataContext context) : base(context)
        {
        }
    }
}
