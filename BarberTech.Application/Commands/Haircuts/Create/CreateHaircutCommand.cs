using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Create
{
    public class CreateHaircutCommand : IRequest<Nothing>
    {
        public string Name { get; set; } = string.Empty;

        public string? About { get; set; }

        public decimal Price { get; set; }

        public string ImageSource { get; set; } = string.Empty;
    }
}
