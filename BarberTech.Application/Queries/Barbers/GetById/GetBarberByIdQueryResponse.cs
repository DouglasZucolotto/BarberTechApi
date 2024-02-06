namespace BarberTech.Application.Queries.Barbers.GetById
{
    public class GetBarberByIdQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? About { get; set; }

        public string? Photo { get; set; }

        public string Contact { get; set; } = string.Empty;

        public double QntStars { get; set; }

        public string EstablishmentAddress { get; set; } = string.Empty;
    }
}

