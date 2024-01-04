using MediatR;

namespace BarberTech.Application.Commands.Establishments.Update
{
    public class UpdateEstablishmentCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public Guid FeedbackId { get; set; }

        public string Address { get; set; }

        public string Coordinates { get; set; }

        public string ImageSource { get; set; }

        public string? Description { get; set; }

        public string BusinessHours { get; set; }

        public UpdateEstablishmentCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
