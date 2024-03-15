using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IEstablishmentRepository : IRepository<Establishment>
    {
        Task<Establishment?> GetByIdToDeleteAsync(Guid id);

        Task<List<Barber>> GetBarbersAsync(Guid id, string? searchTerm, string[] properties);

        Task<List<Establishment>> GetAllFilteredAsync(string? searchTerm, string[] properties);
    }
}
