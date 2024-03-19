using BarberTech.Application.Queries.Users.Dtos;
using BarberTech.Domain.Entities.Enums;
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
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                _notification.AddNotFound("User does not exists");
                return default;
            }

            var schedules = user.Type == UserType.Barber
                ? user.Barber.EventSchedules
                : user.EventSchedules;

            return new GetUserByIdQueryResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Type = user.Type.ToString(),
                ImageSource = user.ImageSource,
                EventSchedules = schedules.Select(es => new EventScheduleDto
                {
                    Id = es.Id,
                    UserName = es.Name ?? es.User.Name,
                    BarberName = es.Barber.User.Name,
                    DateTime = es.DateTime,
                    Status = es.EventStatus.ToString(),
                    FeedbackId = es.FeedbackId,
                    Haircut = new HaircutDto
                    {
                        Id = es.Haircut.Id,
                        Name = es.Haircut.Name,
                        ImageSource = es.Haircut.ImageSource
                    }
                })
            };
        }
    }
}
