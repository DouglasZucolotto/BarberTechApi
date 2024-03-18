using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class HaircutRepository : Repository<Haircut>, IHaircutRepository
    {
        public HaircutRepository(DataContext context) : base(context)
        {
        }

        public async override Task<(List<Haircut> items, int totalCount)> GetAllPagedAsync(int page, int pageSize, string? searchTerm, string[] properties)
        {
            var filter = Query.Filter(searchTerm, properties);
            var totalCount = filter.Count();

            var items = await filter
                .Include(h => h.Feedbacks)
                .Paginate(page, pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public Task<Haircut?> GetByIdToDeleteAsync(Guid id)
        {
            return Query
                .Include(h => h.EventSchedules)
                .Include(h => h.Feedbacks)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public Task<List<Haircut>> GetAllFilteredAsync(string? searchTerm, string[] properties)
        {
            return Query
                .Filter(searchTerm, properties)
                .ToListAsync();
        }
    }
}
