using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQuery : IRequest<IEnumerable<GetFeedbacksQueryResponse>>
    {
    }
}
