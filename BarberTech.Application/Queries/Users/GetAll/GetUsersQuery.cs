using MediatR;

namespace BarberTech.Application.Queries.Users.GetAll
{
    public class GetUsersQuery : IRequest<IEnumerable<GetUsersQueryResponse>>
    {
    }
}
