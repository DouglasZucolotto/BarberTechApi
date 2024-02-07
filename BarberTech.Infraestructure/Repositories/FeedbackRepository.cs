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

        public Task<List<Feedback>> GetAllWithUserAsync()
        {
            return Query
                .Include(f => f.User)
                .ToListAsync();
        }
    }
}
