using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommand : IRequest<Nothing>
    {
        public string? Comment { get; set; }
        
        public Guid EventScheduleId { get; set; }

        public int QntStarsBarber { get; set; }

        public int QntStarsHaircut { get; set; }

        public int QntStarsEstablishment { get; set; }
    }
}
