using BarberTech.Domain;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Users.GetAll
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Paged<GetUsersQueryResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Paged<GetUsersQueryResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "Name", "Email" };

            var (items, totalCount) = await _userRepository.GetAllPagedAsync(
                request.Page, 
                request.PageSize, 
                request.SearchTerm,
                filterProps);

            var users = items.Select(user => new GetUsersQueryResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Type = user.Type.ToString(),
            });

            return new Paged<GetUsersQueryResponse>(users, request.Page, request.PageSize, totalCount);
        }
    }
}
