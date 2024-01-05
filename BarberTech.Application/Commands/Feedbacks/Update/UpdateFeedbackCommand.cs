﻿using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Feedbacks.Update
{
    public class UpdateFeedbackCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string? Comment { get; set; }

        public int QntStars { get; set; }

        public UpdateFeedbackCommand WithId(Guid id)
        {
            Id = id;
            return this;
        }
    }
}
