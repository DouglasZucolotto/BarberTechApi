using BarberTech.Application.Queries.Haircuts.Dtos;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQueryHandler : IRequestHandler<GetHaircutByIdQuery, GetHaircutByIdQueryResponse?>
    {
        private readonly IHaircutRepository _haircutRepository;
        private readonly INotificationContext _notification;

        public GetHaircutByIdQueryHandler(IHaircutRepository haircutRepository, INotificationContext notification)
        {
            _haircutRepository = haircutRepository;
            _notification = notification;
        }

        public async Task<GetHaircutByIdQueryResponse?> Handle(GetHaircutByIdQuery request, CancellationToken cancellationToken)
        {
            var haircut = await _haircutRepository.GetByIdWithFeedbacksAsync(request.Id);

            if (haircut is null)
            {
                _notification.AddNotFound("Haircut does not exists");
                return default;
            }

            return new GetHaircutByIdQueryResponse
            {
                Id = haircut.Id,
                Name = haircut.Name,
                Description = haircut.Description,
                ImageSource = haircut.ImageSource,
                Price = haircut.Price,
                QtdStars = haircut.GetFeedbacksAverage(),
                Feedbacks = haircut.Feedbacks.Select(f => new FeedbackDto
                {
                    QntStars = f.QntStars,
                    Comment = f.Comment,
                    At = f.CreatedAt,
                    User = new UserDto
                    {
                        Name = f.User.Name,
                    }
                })
            };
        }
    }
}
