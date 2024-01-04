using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using BarberTech.Domain.Repositories;
using BarberTech.Domain.Entities;

namespace BarberTech.Application.Commands.Feedbacks.EvaluateHaircut
{
    public class EvaluateHaircutCommandHandler : IRequestHandler<EvaluateHaircutCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IHaircutRepository _haircutRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EvaluateHaircutCommandHandler(
            IFeedbackRepository feedbackRepository,
            IHaircutRepository haircutRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _feedbackRepository = feedbackRepository;
            _httpContextAccessor = httpContextAccessor;
            _haircutRepository = haircutRepository;
        }

        public async Task<Nothing> Handle(EvaluateHaircutCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // TODO: fazer um context para acessar o usuário logado
            
            var haircut = await _haircutRepository.GetByIdAsync(request.HaircutId);

            if (haircut == null)
            {
                //TODO: bad request
                return default;
            }

            var feedback = new Feedback(Guid.Parse(userId), request.Comment, request.QntStars);
            feedback.EvaluateHaircut(haircut);
           
            _feedbackRepository.Add(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
