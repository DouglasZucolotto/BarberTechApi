using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Task<List<Feedback>> GetAllWithUserAsync();
    }
}
