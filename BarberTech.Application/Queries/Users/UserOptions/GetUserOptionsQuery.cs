using MediatR;

namespace BarberTech.Application.Queries.Users.UserOptions
{
    public class GetUserOptionsQuery : IRequest<IEnumerable<GetUserOptionsQueryResponse>>
    {
        public string? SearchTerm { get; set; }
    }
}
