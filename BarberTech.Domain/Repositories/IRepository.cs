using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IUnitOfWork UnitOfWork { get; }

        Task<List<TEntity>> GetAllAsync();

        Task<(List<TEntity> items, int totalCount)> GetAllPagedAsync(int page, int pageSize, string? searchTerm, string[] properties);

        Task<TEntity?> GetByIdAsync(Guid id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
