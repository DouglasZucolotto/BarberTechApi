using MediatR;

namespace BarberTech.Application.Queries.Barbers.GetById
{
    public class GetBarberByIdQuery : IRequest<GetBarberByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetBarberByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
