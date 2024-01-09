using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;

namespace BarberTech.Infraestructure.Repositories
{
    public class EstablishmentRepository : Repository<Establishment>, IEstablishmentRepository
    {
        public EstablishmentRepository(DataContext context) : base(context)
        {
        }
    }
}
