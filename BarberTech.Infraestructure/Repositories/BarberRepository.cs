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

        public async Task<(int Count, List<Barber> Barbers)> GetAllBarbersPagedAsync(int page, int pageSize)
        {
            var count = await Query.CountAsync();

            var barbers = await Query
                .Include(b => b.User)
                .Include(b => b.Feedbacks)
                .Include(b => b.Establishment)
                .Include(b => b.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (count, barbers);
        }

        public Task<List<Barber>> GetAllWithUserAsync()
        {
            return Query
                .Include(b => b.User)
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
