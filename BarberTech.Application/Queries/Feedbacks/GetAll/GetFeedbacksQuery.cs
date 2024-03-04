using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQuery : IRequest<Paged<GetFeedbacksQueryResponse>>
    { 
        public int Page { get; set; }

        public int PageSize { get; set; }

        public string? SearchTerm { get; set; }
    }
}
