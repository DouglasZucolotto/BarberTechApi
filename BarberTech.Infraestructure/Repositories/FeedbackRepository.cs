using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DataContext context) : base(context)
        {
        }

        public async override Task<(List<Feedback> items, int totalCount)> GetAllPagedAsync(int page, int pageSize, string? searchTerm, string[] properties)
        {
            var filter = Query.Filter(searchTerm, properties);
            var totalCount = filter.Count();

            var items = await filter
                .Include(f => f.User)
                .Include(f => f.Haircut)
                .Include(f => f.Barber).ThenInclude(b => b.User)
                .Include(f => f.Establishment)
                .Paginate(page, pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public Task<Feedback?> GetByIdToDeleteAsync(Guid id)
        {
            return Query
                .Include(f => f.Establishment)
                .Include(f => f.Haircut)
                .Include(f => f.User)
                .Include(f => f.Barber)
                .Include(f => f.EventSchedule)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
