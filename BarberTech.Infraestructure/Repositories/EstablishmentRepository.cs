using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class EstablishmentRepository : Repository<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(DataContext context) : base(context)
        {
        }

        public async override Task<(List<Establishment> items, int totalCount)> GetAllPagedAsync(int page, int pageSize, string? searchTerm, string[] properties)
        {
            var filter = Query.Filter(searchTerm, properties);
            var totalCount = filter.Count();

            var items = await filter
                .Include(e => e.Feedbacks)
                .Paginate(page, pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public Task<Establishment?> GetByIdToDeleteAsync(Guid id)
        {
            return Query
                .Include(e => e.Feedbacks).ThenInclude(f => f.EventSchedule)
                .Include(e => e.Barbers)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<List<Barber>> GetBarbersAsync(Guid id, string? searchTerm, string[] properties)
        {
            return Query
                .Where(e => e.Id == id)
                .Include(e => e.Barbers).ThenInclude(b => b.User)
                .SelectMany(e => e.Barbers)
                .Filter(searchTerm, properties)
                .ToListAsync();
        }

        public Task<List<Establishment>> GetAllFilteredAsync(string? searchTerm, string[] properties)
        {
            return Query
                .Filter(searchTerm, properties)
                .ToListAsync();
        }
    }
}
