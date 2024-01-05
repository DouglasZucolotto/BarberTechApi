using BarberTech.Application.Queries.Feedbacks.GetAll;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetById
{
    public class GetEstablishmentByIdQuery : IRequest<List<GetEstablishmentByIdQueryResponse>>
    {
        public Guid Id { get; set; }

        public GetEstablishmentByIdQuery WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
