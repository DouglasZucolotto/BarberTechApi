using BarberTech.Application.Queries.Feedbacks.GetAll;
using BarberTech.Infraestructure;

namespace BarberTech.Application.Queries.Feedbacks.GetById
{
    public class GetFeedbackByIdQueryHandler
    {
        private readonly DataContext _context;

        public GetFeedbackByIdQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GetFeedbackByIdQueryResponse> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
        {
            var feedback = _context.Feedbacks.FirstOrDefault(f => f.Id == request.Id);

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
