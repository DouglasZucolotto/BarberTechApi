using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class EstablishmentRepository : Repository<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(DataContext context) : base(context)
        {
        }

        public Task<Establishment> GetByIdWithBarbersAsync(Guid id)
        {
            return Query
                .Include(e => e.Barbers)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
