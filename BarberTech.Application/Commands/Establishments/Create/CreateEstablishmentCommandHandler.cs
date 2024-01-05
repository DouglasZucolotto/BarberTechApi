using BarberTech.Application.Commands.Feedbacks.Create;
using BarberTech.Infraestructure;
using BarberTech.Infraestructure.Entities;
using MediatR;

namespace BarberTech.Application.Commands.Establishments.Create
{
    public class CreateEstablishmentCommandHandler : IRequestHandler<CreateEstablishmentCommand, Nothing>
    {
        private readonly DataContext _context;

        public CreateEstablishmentCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Nothing> Handle(CreateEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishment = new Establishment(request.Id, request.FeedbackId, request.Address, request.Coordinates, request.Description, request.BusinessHours, request.ImageSource);
            {
                _context.Establishments.Add(establishment);
                await _context.SaveChangesAsync();

                return Nothing.Value;
            };
        }
    }
}
