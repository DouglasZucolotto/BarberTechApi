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

        public Task<List<Haircut>> GetAllWithFeedbacksAsync()
        {
            return Query
                .Include(h => h.Feedbacks)
                    .ThenInclude(f => f.User)
                .ToListAsync();
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
