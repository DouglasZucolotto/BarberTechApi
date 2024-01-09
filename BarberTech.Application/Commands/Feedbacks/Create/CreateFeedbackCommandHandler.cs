using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Guid>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateFeedbackCommandHandler(IFeedbackRepository feedbackRepository, IHttpContextAccessor httpContextAccessor)
        {
            _feedbackRepository = feedbackRepository ?? throw new ArgumentNullException(nameof(feedbackRepository));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public async Task<Guid> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null || !Guid.TryParse(userId, out var userGuid))
            {
                throw new ApplicationException("User ID not found or invalid in the token.");
            }

            if (request.EstablishmentId == null)
            {
                throw new ArgumentNullException(nameof(request.EstablishmentId));
            }

            var feedback = new Feedback(userGuid, request.Comment, request.QntStars);

            _feedbackRepository.Add(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return feedback.Id;
        }
    }
}
