using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IHaircutRepository : IRepository<Haircut>
    {
        Task<List<Haircut>> GetAllWithFeedbacksAsync();

        Task<Haircut?> GetByIdWithFeedbacksAsync(Guid id);
    }
}
