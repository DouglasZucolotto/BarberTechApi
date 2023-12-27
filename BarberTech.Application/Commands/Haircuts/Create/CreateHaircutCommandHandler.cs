using BarberTech.Infraestructure;
using BarberTech.Infraestructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

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
            var file = await ConvertFormFileToByteArrayAsync(request.File);
            var photo = new Photo(file);

            var haircut = new Haircut(request.Name, request.Description ?? string.Empty, photo, request.Price);

            _context.Haircuts.Add(haircut);
            await _context.SaveChangesAsync();

            return Nothing.Value;
        }

        private async Task<byte[]> ConvertFormFileToByteArrayAsync(IFormFile formFile)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
