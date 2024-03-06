namespace BarberTech.Application.Queries.Establishments.GetById
{
    public class GetEstablishmentByIdQueryResponse
    {
        public Guid Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public string ImageSource { get; set; } = string.Empty;

        public string OpenTime { get; set; } = string.Empty;

        public string LunchTime { get; set; } = string.Empty;

        public string WorkInterval { get; set; } = string.Empty;

        public string LunchInterval { get; set; } = string.Empty;
    }
}

