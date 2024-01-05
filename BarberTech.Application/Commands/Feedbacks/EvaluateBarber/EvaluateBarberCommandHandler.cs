using MediatR;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using BarberTech.Domain.Repositories;
using BarberTech.Domain.Entities;
using BarberTech.Domain;
using BarberTech.Domain.Authentication;

namespace BarberTech.Application.Commands.Feedbacks.EvaluateBarber
{
    public class EvaluateBarberCommandHandler : IRequestHandler<EvaluateBarberCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IBarberRepository _barberRepository;
        private readonly IHttpContext _userContext;

        public EvaluateBarberCommandHandler(
            IFeedbackRepository feedbackRepository, 
            IBarberRepository barberRepository,
            IHttpContext userContext)
        {
            _feedbackRepository = feedbackRepository;
            _userContext = userContext;
            _barberRepository = barberRepository;
        }

        public async Task<Nothing> Handle(EvaluateBarberCommand request, CancellationToken cancellationToken)
        {
            var userId = _userContext.GetUserId();
            
            var barber = await _barberRepository.GetByIdAsync(request.BarberId);

            if (barber == null)
            {
                //TODO: bad request
                return default;
            }

            var feedback = new Feedback(userId, request.Comment, request.QntStars);
            feedback.EvaluateBarber(barber);
           
            _feedbackRepository.Add(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
