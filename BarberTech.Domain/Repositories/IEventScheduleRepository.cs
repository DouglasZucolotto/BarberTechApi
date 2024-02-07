using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Repositories
{
    public interface IEventScheduleRepository : IRepository<EventSchedule>
    {
        Task<EventSchedule?> GetByIdWithEstablishment(Guid id);
    }
}
