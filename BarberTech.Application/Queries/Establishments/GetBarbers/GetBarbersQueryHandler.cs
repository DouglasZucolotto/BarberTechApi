using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetBarbers
{
    public class GetBarbersQueryHandler : IRequestHandler<GetBarbersQuery, IEnumerable<GetBarbersQueryResponse>>
    {
        private readonly IEstablishmentRepository _establishmentRepository;

        public GetBarbersQueryHandler(IEstablishmentRepository establishmentRepository)
        {
            _establishmentRepository = establishmentRepository;
        }

        public async Task<IEnumerable<GetBarbersQueryResponse>> Handle(GetBarbersQuery request, CancellationToken cancellationToken)
        {
            var filterProps = new string[] { "User", "Name" };

            var barbers = await _establishmentRepository.GetBarbersAsync(request.Id, request.SearchTerm, filterProps);

            return barbers.Select(b => new GetBarbersQueryResponse()
            {
                Id = b.Id,
                Name = b.User.Name,
            });
        }
    }
}
