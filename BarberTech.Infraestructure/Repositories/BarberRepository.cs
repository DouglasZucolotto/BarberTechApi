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

        public async override Task<(List<Barber> items, int totalCount)> GetAllPagedAsync(int page, int pageSize, string? searchTerm, string[] properties)
        {
            var filter = Query.Filter(searchTerm, properties);
            var totalCount = filter.Count();

            var items = await filter
                .Include(b => b.User)
                .Include(b => b.Feedbacks)
                .Paginate(page, pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public override Task<Barber?> GetByIdAsync(Guid id)
        {
            return Query
                .Include(b => b.User)
                .Include(b => b.Establishment)
                .Include(u => u.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                .Include(u => u.EventSchedules).ThenInclude(es => es.User)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<Barber?> GetByIdWithSchedulesAsync(Guid id)
        {
            return Query
                .Include(b => b.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                .Include(b => b.Establishment)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
