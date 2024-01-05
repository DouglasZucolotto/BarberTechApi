using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetById
{
    public class GetFeedbackByIdQuery : IRequest<GetFeedbackByIdQueryResponse>
    {
        public GetFeedbackByIdQuery(Guid id) 
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}

