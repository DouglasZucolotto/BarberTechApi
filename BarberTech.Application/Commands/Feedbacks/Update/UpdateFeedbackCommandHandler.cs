using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Update
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly INotificationContext _notification;

        public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, INotificationContext notification)
        {
            _feedbackRepository = feedbackRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id);

            if (feedback is null)
            {
                _notification.AddNotFound("Feedback does not exists");
                return default;
            }

            feedback.Comment = request.Comment ?? feedback.Comment;
            feedback.QntStars = request.QntStars ?? feedback.QntStars;

            _feedbackRepository.Update(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
