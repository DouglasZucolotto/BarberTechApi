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
                .Include(h => h.Feedbacks)
                .Paginate(page, pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
