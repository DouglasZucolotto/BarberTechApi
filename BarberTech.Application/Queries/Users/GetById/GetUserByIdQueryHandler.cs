using BarberTech.Application.Queries.Users.GetAll;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Users.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse>
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

            return new GetUserByIdQueryResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                ImageSource = user.ImageSource,
            };
        }
    }
}
