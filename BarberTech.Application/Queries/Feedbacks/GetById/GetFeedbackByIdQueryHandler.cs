using BarberTech.Application.Queries.Feedbacks.GetAll;
using BarberTech.Infraestructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return default;
            }

            return new GetFeedbackByIdQueryResponse
            {
                Id = feedback.Id,
                UserId = feedback.UserId,
                Comment = feedback.Comment,
                Qnt_stars = feedback.Qnt_stars,
                HaircutId = feedback.FeedbackId
            };
        }
    }
}
