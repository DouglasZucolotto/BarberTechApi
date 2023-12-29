using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQueryHandler : IRequestHandler<GetHaircutByIdQuery, GetHaircutByIdQueryResponse>
    {
        private readonly DataContext _context;

        public GetHaircutByIdQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GetHaircutByIdQueryResponse> Handle(GetHaircutByIdQuery request, CancellationToken cancellationToken)
        {
            var haircut = _context.Haircuts.FirstOrDefault(h => h.Id == request.Id);

            if (haircut is null)
            {
                // TODO: notificator
                return default;
            }

            return new GetHaircutByIdQueryResponse
            {
                Id= haircut.Id,
                Name = haircut.Name,
                Description = haircut.Description,
                ImageSource = haircut.ImageSource,
                Price = haircut.Price
            };
        }
    }
}
