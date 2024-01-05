using BarberTech.Application.Commands.Feedbacks.Update;
using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommandHandler : IRequestHandler<UpdateEstablishmentCommand, Nothing>
    {
        private readonly DataContext _context;

        public UpdateEstablishmentCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<Nothing> Handle(UpdateEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishment = _context.Establishments.FirstOrDefault(e => e.Id == request.Id);

            if (establishment is null)
            {
                return Nothing.Value;
            }

            establishment.Id = request.Id;
            establishment.FeedbackId = request.FeedbackId;
            establishment.Address = request.Address;
            establishment.Coordinates = request.Coordinates;
            establishment.ImageSource = request.ImageSource;
            establishment.Description = request.Description;
            establishment.BusinessHours = request.BusinessHours;

            _context.Establishments.Update(establishment);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
