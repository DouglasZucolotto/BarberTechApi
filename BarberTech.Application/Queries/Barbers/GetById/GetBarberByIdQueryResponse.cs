using BarberTech.Application.Queries.Barbers.Dtos;

namespace BarberTech.Application.Queries.Barbers.GetById
{
    public class GetBarberByIdQueryResponse
    {
        public Guid Id { get; set; }

        public Guid? EstablishmentId { get; set; }

        public string? About { get; set; }

        public SocialDto Social { get; set; } = new SocialDto();

        public string Contact { get; set; } = string.Empty;

        public IEnumerable<EventScheduleDto> EventSchedules { get; set; } = Enumerable.Empty<EventScheduleDto>();
    }
}

