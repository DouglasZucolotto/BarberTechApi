using MediatR;

namespace BarberTech.Application.Commands.Haircuts.Delete
{
    public class DeleteHaircutCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public DeleteHaircutCommand (Guid id)
        {
            Id = id;
        }
    }
}
