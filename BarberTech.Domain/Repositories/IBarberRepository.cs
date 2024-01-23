using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IBarberRepository : IRepository<Barber>
    {
        public Task<List<Barber>> GetAllBarbersAsync();

        public Task<Barber> GetBarberWithUserByIdAsync(Guid id);

        public Task<List<DateTime>> GetAvailableTimesAsync(Guid barberId);

    }
}
