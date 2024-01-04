using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.EvaluateHaircut
{
    public class EvaluateHaircutCommand : IRequest<Nothing>
    {
        public string? Comment { get; set; }

        public int QntStars { get; set; }

        public Guid HaircutId { get; set; }
    }
}

