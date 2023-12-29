using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksQuery, List<GetFeedbacksQueryResponse>>
    {
        private readonly DataContext _context;

        public GetFeedbacksQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GetFeedbacksQueryResponse>> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var feedbacks = _context.Feedbacks
                .Select(feedback => new GetFeedbacksQueryResponse
                {
                    Id = feedback.Id,
                    Comment = feedback.Comment,
                    QntStars = feedback.QntStars
                })
                .ToList();

            return feedbacks;
        }
    }
}
