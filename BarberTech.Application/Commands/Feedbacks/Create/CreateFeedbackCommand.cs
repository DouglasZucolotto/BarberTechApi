using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommand : IRequest<Nothing>
    {
        public string? Comment { get; set; }
        
        public Guid EventScheduleId { get; set; }

        public int RatingBarber { get; set; }

        public int RatingHaircut { get; set; }

        public int RatingEstablishment { get; set; }
    }
}
