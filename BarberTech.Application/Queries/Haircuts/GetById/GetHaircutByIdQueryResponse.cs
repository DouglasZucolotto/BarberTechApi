namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? About { get; set; }

        public decimal Price { get; set; }

        public string ImageSource { get; set; } = string.Empty;

        public double Rating { get; set; }
    }
}
