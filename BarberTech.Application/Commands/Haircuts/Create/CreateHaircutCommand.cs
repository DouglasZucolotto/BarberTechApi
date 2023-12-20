using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Create
{
    public class CreateHaircutCommand : IRequest<Nothing>
    {
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string PhotoURL { get; set; } = string.Empty;

        public decimal Price { get; set; }
    }
}
