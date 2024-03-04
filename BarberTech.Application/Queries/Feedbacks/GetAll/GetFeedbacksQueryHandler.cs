using BarberTech.Application.Queries.Establishments.GetAll;
using BarberTech.Domain;
using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQueryHandler : IRequestHandler<GetFeedbacksQuery, Paged<GetFeedbacksQueryResponse>>
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public GetFeedbacksQueryHandler(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<Paged<GetFeedbacksQueryResponse>> Handle(GetFeedbacksQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "Comment" };

            var (items, totalCount) = await _feedbackRepository.GetAllPagedAsync(request.Page, request.PageSize, request.SearchTerm, filterProps);

            var feedbacks = items
                .Select(feedback => new GetFeedbacksQueryResponse
                {
                    Id = feedback.Id,
                    Comment = feedback.Comment,
                    At = feedback.CreatedAt.ToString("dd/MM/yyyy"),
                    RatingAverage = feedback.GetRatingAverage(),
                    UserName = feedback.User.Name
                });

            return new Paged<GetFeedbacksQueryResponse>(feedbacks, request.Page, request.PageSize, totalCount); 
        }
    }
}
