﻿using BarberTech.Domain;
using MediatR;
using System.Text.Json.Serialization;

namespace BarberTech.Application.Commands.Barbers.ScheduleHaircut
{
    public class ScheduleHaircutCommand : IRequest<Nothing>
    {
        [JsonIgnore]
        public Guid BarberId { get; set; }

        public string? Name { get; set; }

        public Guid EstablishmentId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public ScheduleHaircutCommand WithId(Guid barberId)
        {
            BarberId = barberId;
            return this;
        }
    }
}