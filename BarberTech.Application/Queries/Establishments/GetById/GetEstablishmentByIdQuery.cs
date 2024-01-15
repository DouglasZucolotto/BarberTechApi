using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetById
{
    public class GetEstablishmentByIdQuery : IRequest<GetEstablishmentByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetEstablishmentByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
