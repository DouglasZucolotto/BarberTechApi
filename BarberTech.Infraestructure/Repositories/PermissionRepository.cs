using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;

namespace BarberTech.Infraestructure.Repositories
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        public PermissionRepository(DataContext context) : base(context)
        {
        }
    }
}
