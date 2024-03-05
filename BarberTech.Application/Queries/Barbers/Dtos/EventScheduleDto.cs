﻿namespace BarberTech.Application.Queries.Barbers.Dtos
{
    public class EventScheduleDto
    {
        public Guid Id { get; set; }

        public DateTime DateTime { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string BarberName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public Guid? FeedbackId { get; set; }
    }
}
