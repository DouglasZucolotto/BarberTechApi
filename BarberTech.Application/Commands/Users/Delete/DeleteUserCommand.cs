using MediatR;

namespace BarberTech.Application.Commands.Users.Delete
{
    public class DeleteUserCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
