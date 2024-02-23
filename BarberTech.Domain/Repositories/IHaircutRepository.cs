using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IHaircutRepository : IRepository<Haircut>
    {
        Task<(int Count, List<Haircut> Haircuts)> GetAllWithFeedbacksPagedAsync(int page, int pageSize);

        Task<Haircut?> GetByIdWithFeedbacksAsync(Guid id);
    }
}
