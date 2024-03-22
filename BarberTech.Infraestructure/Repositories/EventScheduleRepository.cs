using BarberTech.Domain.Entities;
using BarberTech.Domain.Entities.Enums;
using BarberTech.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Repositories
{
    public class EventScheduleRepository : Repository<EventSchedule>, IEventScheduleRepository
    {
        public EventScheduleRepository(DataContext context) : base(context)
        {
        }

        public async override Task<(List<EventSchedule> items, int totalCount)> GetAllPagedAsync(int page, int pageSize, string? searchTerm, string[] properties)
        {
            var filter = Query.Filter(searchTerm, properties);
            var totalCount = filter.Count();

            var items = await filter
                .Where(es => es.EventStatus == EventStatus.Active)
                .Include(es => es.Haircut)
                .Include(es => es.Barber).ThenInclude(b => b.User)
                .Paginate(page, pageSize)
                .ToListAsync();

            return (items, totalCount);
        }

        public Task<EventSchedule?> GetByIdWithEstablishment(Guid id)
        {
            return Query
                .Include(es => es.Barber)
                    .ThenInclude(b => b.Establishment)
                .Include(es => es.Haircut)
                .FirstOrDefaultAsync(es => es.Id == id);
        }  
    }
}
