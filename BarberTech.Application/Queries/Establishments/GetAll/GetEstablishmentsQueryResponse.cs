namespace BarberTech.Application.Queries.Establishments.GetAll
{
    public class GetEstablishmentsQueryResponse
    {
        public Guid Id { get; set; }

        public string Address { get; set; } = string.Empty;

        public string ImageSource { get; set; } = string.Empty;

        public string BusinessTime { get; set; } = string.Empty;

        public double Rating { get; set; }
    }
}
