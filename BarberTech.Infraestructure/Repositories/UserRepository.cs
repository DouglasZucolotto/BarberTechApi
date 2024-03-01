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

        public Task<List<User>> GetAllWithEventSchedulesAsync()
        {
            return Query
                .Include(u => u.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                .Include(u => u.Barber)
                    .ThenInclude(b => b.Establishment)
                .ToListAsync();
        }

        public Task<User?> GetByIdWithEventSchedulesAsync(Guid id)
        {
            return Query
                .Include(u => u.EventSchedules
                    .Where(es => es.EventStatus != EventStatus.Canceled))
                    .ThenInclude(es => es.Barber)
                        .ThenInclude(b => b.User)
                //.Include(u => u.Barber)
                    //.ThenInclude(b => b.User)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return Query.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User?> GetWithPermissionsAsync(Guid id)
        {
            return Query.Include(u => u.Permissions).FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<bool> UserEmailExistsAsync(string email)
        {
            return Query.AnyAsync(u => u.Email == email);
        }
    }
}
