using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts
{
    public class GetHaircutsQueryHandler : IRequestHandler<GetHaircutsQuery, List<GetHaircutsQueryResponse>>
    {
        private readonly DataContext _context;

        public GetHaircutsQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GetHaircutsQueryResponse>> Handle(GetHaircutsQuery request, CancellationToken cancellationToken)
        {
            var haircuts = _context.Haircuts
                .Select(haircut => new GetHaircutsQueryResponse
                {
                    Id = haircut.Id,
                    Name = haircut.Name,
                    Description = haircut.Description,
                    Price = haircut.Price,
                    ImageSource = haircut.ImageSource
                })
                .ToList();

            return haircuts;
        }
    }
}
