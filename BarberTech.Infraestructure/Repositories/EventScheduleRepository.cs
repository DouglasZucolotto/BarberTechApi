using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class EventScheduleRepository : Repository<EventSchedule>, IEventScheduleRepository
    {
        public EventScheduleRepository(DataContext context) : base(context)
        {
        }

        public Task<EventSchedule?> GetByIdWithEstablishment(Guid id)
        {
            return Query
                .Include(es => es.Barber)
                    .ThenInclude(b => b.Establishment)
                .Include(es => es.Haircut)
                .FirstOrDefaultAsync(es => es.Id == id);
        }
    }
}
