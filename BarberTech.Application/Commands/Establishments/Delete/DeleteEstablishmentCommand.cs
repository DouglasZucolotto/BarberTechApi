using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Establishments.Delete
{
    public class DeleteEstablishmentCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public DeleteEstablishmentCommand(Guid id)
        {
            Id = id;
        }
    }
}
