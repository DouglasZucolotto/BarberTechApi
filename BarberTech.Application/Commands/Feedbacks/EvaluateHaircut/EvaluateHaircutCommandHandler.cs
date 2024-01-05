using MediatR;
using BarberTech.Domain.Repositories;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Authentication;

namespace BarberTech.Application.Commands.Feedbacks.EvaluateHaircut
{
    public class EvaluateHaircutCommandHandler : IRequestHandler<EvaluateHaircutCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IHaircutRepository _haircutRepository;
        private readonly IHttpContext _userContext;

        public EvaluateHaircutCommandHandler(
            IFeedbackRepository feedbackRepository,
            IHaircutRepository haircutRepository,
            IHttpContext userContext)
        {
            _feedbackRepository = feedbackRepository;
            _userContext = userContext;
            _haircutRepository = haircutRepository;
        }

        public async Task<Nothing> Handle(EvaluateHaircutCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetUserId();

            var haircut = await _haircutRepository.GetByIdAsync(request.HaircutId);

            if (haircut == null)
            {
                //TODO: bad request
                return default;
            }

            var feedback = new Feedback(userId, request.Comment, request.QntStars);
            feedback.EvaluateHaircut(haircut);
           
            _feedbackRepository.Add(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
