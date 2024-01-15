using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetById
{
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, GetFeedbackByIdQueryResponse?>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly INotificationContext _notification;

        public GetFeedbackByIdQueryHandler(IFeedbackRepository feedbackRepository, INotificationContext notification)
        {
            _feedbackRepository = feedbackRepository;
            _notification = notification;
        }

        public async Task<GetFeedbackByIdQueryResponse?> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id);

            if (feedback is null)
            {
                _notification.AddNotFound("Feedback does not exists");
                return default;
            }

            return new GetFeedbackByIdQueryResponse
            {
                Id = feedback.Id,
                Comment = feedback.Comment,
                QntStars = feedback.QntStars
            };
        }
    }
}
