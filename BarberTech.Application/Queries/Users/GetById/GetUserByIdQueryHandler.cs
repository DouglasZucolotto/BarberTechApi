using BarberTech.Application.Queries.Users.Dtos;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Users.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse?>
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationContext _notification;

        public GetUserByIdQueryHandler(IUserRepository userRepository, INotificationContext notification)
        {
            _userRepository = userRepository;
            _notification = notification;
        }

        public async Task<GetUserByIdQueryResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdWithEventSchedulesAsync(request.Id);

            if (user is null)
            {
                _notification.AddNotFound("User does not exists");
                return default;
            }

            return new GetUserByIdQueryResponse
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
                    Status = es.EventStatus.ToString(),
                })
            };
        }
    }
}
