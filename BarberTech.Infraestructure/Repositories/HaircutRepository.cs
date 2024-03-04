using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;

namespace BarberTech.Infraestructure.Repositories
{
    public class HaircutRepository : Repository<Haircut>, IHaircutRepository
    {
        public HaircutRepository(DataContext context) : base(context)
        {
        }
    }
}
