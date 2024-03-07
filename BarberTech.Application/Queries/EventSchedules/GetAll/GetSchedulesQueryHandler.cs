using BarberTech.Domain.Repositories;
using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Queries.EventSchedules.GetAll
{
    public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, Paged<GetSchedulesQueryResponse>>
    {
        private readonly IEventScheduleRepository _eventScheduleRepository;

        public GetSchedulesQueryHandler(IEventScheduleRepository eventScheduleRepository)
        {
            _eventScheduleRepository = eventScheduleRepository;
        }

        public async Task<Paged<GetSchedulesQueryResponse>> Handle(GetSchedulesQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "Name", "Barber", "Haircut" };

            var (items, totalCount) = await _eventScheduleRepository.GetAllPagedAsync(request.Page, request.PageSize, request.SearchTerm, filterProps);

            var schedules = items.Select(schedule => new GetSchedulesQueryResponse
            {
                Id = schedule.Id,
                Name = schedule.Name,
                BarberName = schedule.Barber.User.Name,
                HaircutName = schedule.Haircut.Name,
                Date = schedule.DateTime.ToString(),
                Status = schedule.EventStatus.ToString(),
            });

            return new Paged<GetSchedulesQueryResponse>(schedules, request.Page, request.PageSize, totalCount);
        }
    }
}
