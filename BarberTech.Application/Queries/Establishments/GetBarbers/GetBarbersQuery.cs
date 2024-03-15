using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Queries.Establishments.GetBarbers
{
    public class GetBarbersQuery : IRequest<IEnumerable<GetBarbersQueryResponse>>
    {
        public Guid Id { get; set; }

        public string? SearchTerm { get; set; }

        public GetBarbersQuery(Guid id, string? searchTerm)
        {
            Id = id;
            SearchTerm = searchTerm;
        }
    }
}
