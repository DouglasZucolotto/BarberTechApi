using BarberTech.Application.Queries.Users.Dtos;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Users.GetAll
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<GetUsersQueryResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GetUsersQueryResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetAllWithEventSchedulesAsync();

            return user.Select(user => new GetUsersQueryResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ImageSource = user.ImageSource,
                EventSchedules = user.EventSchedules.Select(es => new EventScheduleDto
                {
                    Id = es.Id,
                    Name = es.Name,
                    DateTime = es.DateTime,
                })
            });
        }
    }
}
