using MediatR;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQuery : IRequest<PagedResponse<GetBarbersQueryResponse>>
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
