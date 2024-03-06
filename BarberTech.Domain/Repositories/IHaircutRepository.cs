using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IHaircutRepository : IRepository<Haircut>
    {
        Task<Haircut?> GetByIdToDeleteAsync(Guid id);
    }
}
