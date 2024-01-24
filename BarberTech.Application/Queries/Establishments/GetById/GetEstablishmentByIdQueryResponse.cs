﻿namespace BarberTech.Application.Queries.Establishments.GetById
{
    public class GetEstablishmentByIdQueryResponse
    {
        public Guid Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string ImageSource { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string BusinessTime { get; set; } = string.Empty;
    }
}

