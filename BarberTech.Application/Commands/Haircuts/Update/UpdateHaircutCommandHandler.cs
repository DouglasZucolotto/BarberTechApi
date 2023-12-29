using BarberTech.Infraestructure;
using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Update
{
    public class UpdateHaircutCommandHandler : IRequestHandler<UpdateHaircutCommand, Nothing>
    {
        private readonly DataContext _context;

        public UpdateHaircutCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Nothing> Handle(UpdateHaircutCommand request, CancellationToken cancellationToken)
        {
            var haircut = _context.Haircuts.FirstOrDefault(h => h.Id == request.Id);

            if (haircut is null)
            {
                // TODO: notificator
                return default;
            }

            haircut.Name = request.Name;
            haircut.Description = request.Description;
            haircut.Price = request.Price;
            haircut.ImageSource = request.ImageSource;

            _context.Haircuts.Update(haircut);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
