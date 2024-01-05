using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Establishments.Delete
{
    public class DeleteEstablishmentCommandHandler : IRequestHandler<DeleteEstablishmentCommand, Nothing>
    {
        private readonly DataContext _context;

        public DeleteEstablishmentCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Nothing> Handle(DeleteEstablishmentCommand request, CancellationToken cancellationToken)
        {
            var establishment = _context.Establishments.FirstOrDefault(e => e.Id == request.Id);

            if (establishment is null)
            {
                return Nothing.Value;
            }

            _context.Establishments.Remove(establishment);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
