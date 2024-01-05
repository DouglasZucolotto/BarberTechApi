using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Update
{
    public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<Nothing> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id);

            if (feedback is null)
            {
                // TODO: notificator
                return default;
            }

            feedback.Comment = request.Comment;
            feedback.QntStars = request.QntStars;

            _feedbackRepository.Update(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
