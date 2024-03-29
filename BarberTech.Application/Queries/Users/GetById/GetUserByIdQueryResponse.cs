﻿using BarberTech.Application.Queries.Users.Dtos;

namespace BarberTech.Application.Queries.Users.GetById
{
    public class GetUserByIdQueryResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string? ImageSource { get; set; }

        public IEnumerable<EventScheduleDto> EventSchedules { get; set; } = Enumerable.Empty<EventScheduleDto>();

        public Guid? BarberId { get; set; }
    }
}
