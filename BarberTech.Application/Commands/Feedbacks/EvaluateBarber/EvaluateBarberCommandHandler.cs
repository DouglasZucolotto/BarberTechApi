using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using BarberTech.Domain.Repositories;
using BarberTech.Domain.Entities;

namespace BarberTech.Application.Commands.Feedbacks.EvaluateBarber
{
    public class EvaluateBarberCommandHandler : IRequestHandler<EvaluateBarberCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IBarberRepository _barberRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EvaluateBarberCommandHandler(
            IFeedbackRepository feedbackRepository, 
            IBarberRepository barberRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _feedbackRepository = feedbackRepository;
            _httpContextAccessor = httpContextAccessor;
            _barberRepository = barberRepository;
        }

        public async Task<Nothing> Handle(EvaluateBarberCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value; // TODO: fazer um context para acessar o usuário logado
            
            var barber = await _barberRepository.GetByIdAsync(request.BarberId);

            if (barber == null)
            {
                //TODO: bad request
                return default;
            }

            var feedback = new Feedback(Guid.Parse(userId), request.Comment, request.QntStars);
            feedback.EvaluateBarber(barber);
           
            _feedbackRepository.Add(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
