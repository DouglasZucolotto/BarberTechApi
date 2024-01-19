using BarberTech.Domain;
using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommand : IRequest<Nothing>
    {
        public string? Comment { get; set; }  

        public int QntStars { get; set; } // TODO: um pra cada um

        public Guid HaircutId { get; set; }
        
        public Guid BarberId { get; set; }

        public Guid EstablishmentId { get; set; }
    }
}
