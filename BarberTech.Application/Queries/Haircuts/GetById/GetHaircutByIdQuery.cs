using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQuery : IRequest<GetHaircutByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetHaircutByIdQuery WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
