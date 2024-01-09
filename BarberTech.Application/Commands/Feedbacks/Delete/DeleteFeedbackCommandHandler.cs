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
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id);

            if (feedback is null)
            {
                _notification.AddBadRequest("Feedback does not exists");
                return default;
            }

            _feedbackRepository.Remove(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
