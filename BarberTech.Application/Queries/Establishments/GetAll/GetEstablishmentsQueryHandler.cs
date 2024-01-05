using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Queries.Establishments.GetAll
{
    public class GetEstablishmentsQueryHandler : IRequestHandler<GetEstablishmentsQuery, List<GetEstablishmentsQueryResponse>>
    {
        private readonly DataContext _context;

        public GetEstablishmentsQueryHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<GetEstablishmentsQueryResponse>> Handle(GetEstablishmentsQuery request, CancellationToken cancellationToken)
        {
            var establishments = _context.Establishments
                .Select(establishment => new GetEstablishmentsQueryResponse
                {
                    Id = establishment.Id,
                    FeedbackId = establishment.FeedbackId,
                    Address = establishment.Address,
                    Coordinates = establishment.Coordinates,
                    ImageSource = establishment.ImageSource,
                    Description = establishment.Description,
                    BusinessHours = establishment.BusinessHours
                })
                .ToList();

            return establishments;
        }
    }
}
