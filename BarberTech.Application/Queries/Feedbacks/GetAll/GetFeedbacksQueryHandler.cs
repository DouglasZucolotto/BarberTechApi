using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksQuery, IEnumerable<GetFeedbacksQueryResponse>>
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public GetFeedbacksQueryHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<GetFeedbacksQueryResponse>> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = await _feedbackRepository.GetAllAsync();

            return feedbacks.Select(feedback => new GetFeedbacksQueryResponse
            {
                Id = feedback.Id,
                Comment = feedback.Comment,
                QntStars = feedback.QntStars
            });
        }
    }
}
