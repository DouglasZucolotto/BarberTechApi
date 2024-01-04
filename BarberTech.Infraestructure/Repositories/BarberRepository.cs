using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;

namespace BarberTech.Infraestructure.Repositories
{
    public class BarberRepository : Repository<Barber>, IBarberRepository
    {
        public BarberRepository(DataContext context) : base(context)
        {
        }
    }
}
