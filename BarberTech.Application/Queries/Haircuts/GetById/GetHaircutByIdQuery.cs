using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQuery : IRequest<GetHaircutByIdQueryResponse>
    {
        public GetHaircutByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
