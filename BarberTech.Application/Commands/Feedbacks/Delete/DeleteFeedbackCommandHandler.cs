using BarberTech.Domain;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Delete
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly INotificationContext _notification;

        public DeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository, INotificationContext notification)
        {
            _feedbackRepository = feedbackRepository;
            _notification = notification;
        }

        public async Task<Nothing> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdToDeleteAsync(request.Id);

            if (feedback is null)
            {
                _notification.AddNotFound("Feedback does not exists");
                return default;
            }

            feedback.EventSchedule.Feedback = null;
            feedback.Establishment.Feedbacks.Remove(feedback);
            feedback.User.Feedbacks.Remove(feedback);
            feedback.Barber.Feedbacks.Remove(feedback);
            feedback.Haircut.Feedbacks.Remove(feedback);

            _feedbackRepository.Remove(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
