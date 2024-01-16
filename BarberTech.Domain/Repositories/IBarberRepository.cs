using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IBarberRepository : IRepository<Barber>
    {
        public Task<List<Barber>> GetAllBarbersAsync();
    }
}
