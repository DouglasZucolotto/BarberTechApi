﻿namespace BarberTech.Application.Queries.Haircuts
{
    public class GetHaircutsQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ImageSource { get; set; }
    }
}
