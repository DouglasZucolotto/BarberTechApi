using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IBarberRepository : IRepository<Barber>
    {
        Task<(int Count, List<Barber> Barbers)> GetAllBarbersPagedAsync(int page, int pageSize);

        Task<Barber?> GetBarberWithUserByIdAsync(Guid id);

        Task<Barber?> GetBarberByIdWithEventSchedulesAsync(Guid id);

        Task<List<Barber>> GetAllWithUserAsync();
    }
}
