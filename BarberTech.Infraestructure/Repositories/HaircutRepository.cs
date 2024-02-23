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

        public async Task<(int Count, List<Haircut> Haircuts)> GetAllWithFeedbacksPagedAsync(int page, int pageSize)
        {
            var count = await Query.CountAsync();

            var haircuts = await Query
                .Include(h => h.Feedbacks)
                    .ThenInclude(f => f.User)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (count, haircuts);
        }

        public Task<Haircut?> GetByIdWithFeedbacksAsync(Guid id)
        {
            return Query
                .Include(h => h.Feedbacks)
                    .ThenInclude(f => f.User)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
