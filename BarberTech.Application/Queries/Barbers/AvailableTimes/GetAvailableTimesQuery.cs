using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BarberTech.Application.Queries.Barbers.AvailableTimes
{
    public class GetAvailableTimesQuery : IRequest<IEnumerable<string>>
    {
        public Guid Id { get; set; }

        public string Date { get; set; } = string.Empty;

        public GetAvailableTimesQuery WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
