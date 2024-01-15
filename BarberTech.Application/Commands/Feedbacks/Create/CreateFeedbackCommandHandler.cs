using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Notifications;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommandHandler : IRequestHandler<CreateFeedbackCommand, Nothing>
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IEstablishmentRepository _establishmentRepository;
        private readonly IHaircutRepository _haircutRepository;
        private readonly IBarberRepository _barberRepository;
        private readonly IHttpContext _httpContext;
        private readonly INotificationContext _notification;

        public CreateFeedbackCommandHandler(
            IFeedbackRepository feedbackRepository, 
            IEstablishmentRepository establishmentRepository,
            IHaircutRepository haircutRepository,
            IBarberRepository barberRepository,
            IHttpContext httpContext,
            INotificationContext notification)
        {
            _feedbackRepository = feedbackRepository;
            _establishmentRepository =establishmentRepository;
            _barberRepository = barberRepository;
            _haircutRepository = haircutRepository;
            _httpContext = httpContext;
            _notification = notification;
        }

        public async Task<Nothing> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
        {
            var userId = _httpContext.GetUserId();

            var establishment = await _establishmentRepository.GetByIdAsync(request.EstablishmentId);

            if (establishment == null)
            {
                _notification.AddNotFound("Establishment does not exists");
                return default;
            }

            var haircut = await _haircutRepository.GetByIdAsync(request.HaircutId);

            if (haircut == null)
            {
                _notification.AddNotFound("Haircut does not exists");
                return default;
            }

            var barber = await _barberRepository.GetByIdAsync(request.BarberId);

            if (barber == null)
            {
                _notification.AddNotFound("Barber does not exists");
                return default;
            }

            var feedback = new Feedback(userId, request.Comment, request.QntStars, establishment.Id, haircut.Id, barber.Id);

            _feedbackRepository.Add(feedback);
            await _feedbackRepository.UnitOfWork.CommitAsync();

            return Nothing.Value;
        }
    }
}
