using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Barbers.Delete
{
    public class DeleteBarberCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public DeleteBarberCommand(Guid id)
        {
            Id = id;
        }
    }
}
