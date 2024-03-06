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
                .Include(es => es.Haircut)
                .Include(es => es.Barber)
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

        public Task<Dictionary<DateTime, List<EventSchedule>>> GetSchedulesByBarberId(Guid barberId)
        {
            return Query
                .Where(es => es.BarberId == barberId &&
                    es.EventStatus == EventStatus.Active &&
                    es.DateTime >= DateTime.Today &&
                    es.DateTime < DateTime.Today.AddDays(14))
                .GroupBy(es => es.DateTime.Date)
                .ToDictionaryAsync(g => g.Key, g => g.ToList());
        }      
    }
}
