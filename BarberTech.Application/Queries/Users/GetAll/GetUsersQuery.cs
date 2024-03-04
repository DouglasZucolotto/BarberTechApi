using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Queries.Users.GetAll
{
    public class GetUsersQuery : IRequest<Paged<GetUsersQueryResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string? SearchTerm { get; set; }
    }
}
