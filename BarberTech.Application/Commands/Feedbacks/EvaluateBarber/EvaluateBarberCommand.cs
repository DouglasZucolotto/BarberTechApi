using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.EvaluateBarber
{
    public class EvaluateBarberCommand : IRequest<Nothing>
    {
        public string? Comment { get; set; }

        public int QntStars { get; set; }

        public Guid BarberId { get; set; }
    }
}

