using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
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
