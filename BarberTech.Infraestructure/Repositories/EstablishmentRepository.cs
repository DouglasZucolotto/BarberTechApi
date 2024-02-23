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

        public async Task<(int Count, List<Establishment> Establishments)> GetAllWithFeedbacksPagedAsync(int page, int pageSize)
        {
            var count = await Query.CountAsync();

            var establishments = await Query
                .Include(h => h.Feedbacks)
                    .ThenInclude(f => f.User)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (count, establishments);
        }

        public Task<Establishment?> GetByIdWithFeedbacksAsync(Guid id)
        {
            return Query
                .Include(h => h.Feedbacks)
                    .ThenInclude(f => f.User)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
