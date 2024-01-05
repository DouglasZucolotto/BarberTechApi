using BarberTech.Application.Queries.Feedbacks.GetAll;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetById
{
    public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, GetFeedbackByIdQueryResponse>
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public GetFeedbackByIdQueryHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<GetFeedbackByIdQueryResponse> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
        {
            var feedback = await _feedbackRepository.GetByIdAsync(request.Id);

            if (feedback is null)
            {
                // TODO: notificator
                return default;
            }

            return new GetFeedbackByIdQueryResponse
            {
                Id = feedback.Id,
                Comment = feedback.Comment,
                QntStars = feedback.QntStars
            };
        }
    }
}
