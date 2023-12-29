using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommand : IRequest<Nothing>
    {
        public Guid UserId { get; set; }

        public string? Comment { get; set; }

        public int Qnt_stars { get; set; }

        public Guid FeedbackId { get; set; }
    }
}

