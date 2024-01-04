using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetById
{
    public class GetFeedbackByIdQuery : IRequest<GetFeedbackByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetFeedbackByIdQuery WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}

