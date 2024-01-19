using MediatR;

namespace BarberTech.Application.Queries.Users.GetById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse>
    {
        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
