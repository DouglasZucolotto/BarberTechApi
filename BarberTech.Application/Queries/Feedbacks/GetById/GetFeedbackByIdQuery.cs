using BarberTech.Application.Queries.Feedbacks.GetById;
using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbackByIdQuery : IRequest<List<GetFeedbackByIdQueryResponse>>
    {
        public Guid Id { get; set; }

        public GetFeedbackByIdQuery WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}

