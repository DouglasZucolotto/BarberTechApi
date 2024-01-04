using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Delete
{
    public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public DeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<Nothing> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id);

            if (feedback is null)
            {
                // TODO: notificator
                return default;
            }

            _feedbackRepository.Remove(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
