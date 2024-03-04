using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IBarberRepository : IRepository<Barber>
    {
        Task<Barber?> GetBarberByIdWithEventSchedulesAsync(Guid id);
    }
}
