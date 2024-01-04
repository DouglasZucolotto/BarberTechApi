using BarberTech.Domain;
using BarberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class Repository<TEntity> where TEntity : Entity
    {
        public Repository(DbContext context)
        {
            Context = context;
        }

        public virtual IUnitOfWork UnitOfWork => (IUnitOfWork)Context;

        protected DbContext Context { get; private set; }

        protected IQueryable<TEntity> Query => Context.Set<TEntity>();

        public Task<List<TEntity>> GetAllAsync() => Query.ToListAsync();

        public Task<TEntity?> GetByIdAsync(Guid id) => Query.FirstOrDefaultAsync(x => x.Id == id);

        public void Add(TEntity entity) => Context.Add(entity);

        public void Update(TEntity entity) => Context.Update(entity);

        public void Remove(TEntity entity) => Context.Remove(entity);
    }
}
