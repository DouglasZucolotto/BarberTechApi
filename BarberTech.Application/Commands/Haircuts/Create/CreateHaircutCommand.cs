using MediatR;
using Microsoft.AspNetCore.Http;

namespace BarberTech.Application.Commands.Haircuts.Create
{
    public class CreateHaircutCommand : IRequest<Nothing>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public IFormFile File { get; set; }
    }
}
