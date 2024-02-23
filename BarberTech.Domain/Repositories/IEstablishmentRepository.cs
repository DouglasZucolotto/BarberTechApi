using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IEstablishmentRepository : IRepository<Establishment>
    {
        Task<(int Count, List<Establishment> Establishments)> GetAllWithFeedbacksPagedAsync(int page, int pageSize);

        Task<Establishment?> GetByIdWithFeedbacksAsync(Guid id);
    }
}
