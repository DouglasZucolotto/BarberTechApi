using MediatR;
using System;

namespace BarberTech.Application.Commands.Feedbacks.Update
{
    public class UpdateFeedbackCommand : IRequest<Nothing>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? Comment { get; set; }

        public int Qnt_stars { get; set; }

        public Guid HaircutId { get; set; }
        public Guid FeedbackId { get; internal set; }

        public UpdateFeedbackCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
