using BarberTech.Infraestructure;
using BarberTech.Infraestructure.Entities;
using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Create
{
    public class CreateHaircutCommandHandler : IRequestHandler<CreateHaircutCommand, Nothing>
    {
        private readonly DataContext _context;

        public CreateHaircutCommandHandler(DataContext context)
        {
            _context = context;
        }

        public async Task<Nothing> Handle(CreateHaircutCommand request, CancellationToken cancellationToken)
        {
            var haircut = new Haircut(request.Name, request.Description, request.ImageSource, request.Price);

            _context.Haircuts.Add(haircut);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }
    }
}
