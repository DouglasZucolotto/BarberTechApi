using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Delete
{
    public class DeleteFeedbackCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public DeleteFeedbackCommand(Guid id)
        {
            Id = id;
        }
    }
}

