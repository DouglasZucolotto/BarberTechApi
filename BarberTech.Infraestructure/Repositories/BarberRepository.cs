using BarberTech.Domain.Entities;
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
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Barber?> GetBarberWithUserByIdAsync(Guid id)
        {
            return Query
                .Include(b => b.User)
                .Include(b => b.Feedbacks)
                .Include(b => b.Establishment)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public Task<Barber?> GetBarberByIdWithEventSchedulesAsync(Guid id)
        {
            return Query
                .Include(b => b.EventSchedules)
                .Include(b => b.Establishment)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
