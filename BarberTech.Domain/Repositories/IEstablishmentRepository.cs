using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IEstablishmentRepository : IRepository<Establishment>
    {
        Task<List<Establishment>> GetAllWithFeedbacksAsync();

        Task<Establishment?> GetByIdWithFeedbacksAsync(Guid id);
    }
}
