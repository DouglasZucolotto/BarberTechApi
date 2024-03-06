using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);

        Task<bool> UserEmailExistsAsync(string email);

        Task<User?> GetByIdToDeleteAsync(Guid id);
    }
}
