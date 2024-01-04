using BarberTech.Domain.Repositories;
using MediatR;

namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQueryHandler : IRequestHandler<GetHaircutByIdQuery, GetHaircutByIdQueryResponse>
    {
        private readonly IHaircutRepository _haircutRepository;

        public GetHaircutByIdQueryHandler(IHaircutRepository haircutRepository)
        {
            _haircutRepository = haircutRepository;
        }

        public async Task<GetHaircutByIdQueryResponse> Handle(GetHaircutByIdQuery request, CancellationToken cancellationToken)
        {
            var haircut = await _haircutRepository.GetByIdAsync(request.Id);

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
