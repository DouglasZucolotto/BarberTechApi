using MediatR;

namespace BarberTech.Application.Commands.Feedbacks.Create
{
    public class CreateFeedbackCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; } 

        public string? Comment { get; set; }  

        public int QntStars { get; set; }  

        public Guid? HaircutId { get; set; }
        
        public Guid? BarberId { get; set; }

        public Guid? EstablishmentId { get; set; }

    }
}
