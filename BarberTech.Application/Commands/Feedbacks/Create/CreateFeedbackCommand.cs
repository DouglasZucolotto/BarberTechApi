using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommand : IRequest<Nothing>
    {
        public string? Comment { get; set; }

        public int QntStars { get; set; }

        public Guid? HaircutId { get; set; }

        public Guid? BarberId { get; set; }
    }
}

