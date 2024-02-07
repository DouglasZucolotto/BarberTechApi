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

        public Task<List<Establishment>> GetAllWithFeedbacksAsync()
        {
            return Query
                .Include(h => h.Feedbacks)
                    .ThenInclude(f => f.User)
                .ToListAsync();
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
