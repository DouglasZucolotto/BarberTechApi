using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using BarberTech.Domain.Repositories;
using BarberTech.Domain.Entities;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IHttpContextAccessor httpContextAccessor)
        {
            _feedbackRepository = feedbackRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Nothing> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // TODO: fazer um context para acessar o usuário logado

            var userIdParsed = Guid.Parse(userId);

            var feedback = new Feedback(userIdParsed, request.Comment, request.QntStars);

            if (request.HaircutId != null)
            {
                feedback.EvaluateHaircut(request.HaircutId.Value);
            }

            if (request.BarberId != null)
            {
                feedback.EvaluateBarber(request.BarberId.Value);
            }

            _feedbackRepository.Add(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
