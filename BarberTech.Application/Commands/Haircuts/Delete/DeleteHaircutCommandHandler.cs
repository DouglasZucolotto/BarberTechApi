using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Delete
{
    public class DeleteHaircutCommandHandler : IRequestHandler<DeleteHaircutCommand, Nothing>
    {
        private readonly DataContext _context;

        public DeleteHaircutCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Nothing> Handle(DeleteHaircutCommand request, CancellationToken cancellationToken)
        {
            var haircut = _context.Haircuts.FirstOrDefault(h => h.Id == request.Id);

            if (haircut is null)
            {
                // TODO: notificator
                return default;
            }

            _context.Haircuts.Remove(haircut);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
