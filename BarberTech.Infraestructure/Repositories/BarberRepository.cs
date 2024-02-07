using BarberTech.Domain.Entities;
using BarberTech.Domain.Entities.Enums;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class BarberRepository : Repository<Barber>, IBarberRepository
    {
        public BarberRepository(DataContext context) : base(context)
        {
        }

        public Task<List<Barber>> GetAllBarbersAsync()
        {
            return Query
                .Include(b => b.User)
                .Include(b => b.Feedbacks)
                .Include(b => b.Establishment)
                .Include(b => b.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Barber?> GetBarberWithUserByIdAsync(Guid id)
        {
            return Query
                .Include(b => b.User)
                .Include(b => b.Feedbacks)
                .Include(b => b.Establishment)
                .Include(b => b.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task<Barber?> GetBarberByIdWithEventSchedulesAsync(Guid id)
        {
            return Query
                .Include(b => b.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                .Include(b => b.Establishment)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
