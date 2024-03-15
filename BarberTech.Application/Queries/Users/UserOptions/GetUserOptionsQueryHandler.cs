using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Users.UserOptions
{
    public class GetUserOptionsQueryHandler : IRequestHandler<GetUserOptionsQuery, IEnumerable<GetUserOptionsQueryResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserOptionsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GetUserOptionsQueryResponse>> Handle(GetUserOptionsQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "Name" };

            var users = await _userRepository.GetAllFilteredAsync(request.SearchTerm, filterProps);

            return users.Select(e => new GetUserOptionsQueryResponse()
            {
                Id = e.Id,
                Name = e.Name,
            });
        }
    }
}
