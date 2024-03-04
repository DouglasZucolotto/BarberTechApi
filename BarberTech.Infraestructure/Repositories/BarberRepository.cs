using BarberTech.Domain;
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

        public async override Task<(List<Barber> Items, int TotalCount)> GetAllPagedAsync(int page, int pageSize, string? searchTerm, string[] properties)
        {
            var filter = Query
                .Include(b => b.User)
                .Include(b => b.Feedbacks)
                .Filter(searchTerm, properties);

            var totalCount = filter.Count();

            var items = await filter
                .Paginate(page, pageSize)
                .ToListAsync();

            return (items, totalCount);
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
