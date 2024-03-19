using BarberTech.Domain.Entities;
using BarberTech.Domain.Entities.Enums;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public override Task<User?> GetByIdAsync(Guid id)
        {
            return Query
                .Include(u => u.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                .Include(u => u.EventSchedules).ThenInclude(es => es.Barber).ThenInclude(b => b.User)
                .Include(u => u.EventSchedules).ThenInclude(es => es.Haircut)
                .Include(u => u.Barber).ThenInclude(b => b.EventSchedules).ThenInclude(es => es.Haircut)
                .Include(u => u.Permissions)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User?> GetByIdToDeleteAsync(Guid id)
        {
            return Query
                .Include(u => u.EventSchedules)
                .Include(u => u.Barber).ThenInclude(b => b.Feedbacks).ThenInclude(f => f.EventSchedule)
                .Include(u => u.Barber).ThenInclude(b => b.EventSchedules)
                .Include(u => u.Permissions)
                .Include(u => u.Feedbacks)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return Query.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<bool> UserEmailExistsAsync(string email)
        {
            return Query.AnyAsync(u => u.Email == email);
        }

        public Task<List<User>> GetAllFilteredAsync(string? searchTerm, string[] properties)
        {
            return Query
                .Filter(searchTerm, properties)
                .ToListAsync();
        }
    }
}
