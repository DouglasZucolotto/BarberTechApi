using BarberTech.Infraestructure;

namespace BarberTech.Application.Queries.Establishments.GetById
{
    public class GetEstablishmentByIdQueryHandler
    {
        private readonly DataContext _context;

        public GetEstablishmentByIdQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<GetEstablishmentByIdQueryResponse> Handle(GetEstablishmentByIdQuery request, CancellationToken cancellationToken)
        {
            var establishment = _context.Establishments.FirstOrDefault(e => e.Id == request.Id);

            if (establishment is null)
            {
                return default;
            }

            return new GetEstablishmentByIdQueryResponse
            {
                Id = establishment.Id,
                FeedbackId = establishment.FeedbackId,
                Address = establishment.Address,
                Coordinates = establishment.Coordinates,
                ImageSource = establishment.ImageSource,
                Description = establishment.Description,
                BusinessHours = establishment.BusinessHours
            };
        }
    }
}

