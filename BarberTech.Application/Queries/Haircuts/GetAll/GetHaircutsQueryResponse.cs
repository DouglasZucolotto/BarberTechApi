namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? About { get; set; }

        public decimal Price { get; set; }

        public string ImageSource { get; set; } = string.Empty;

        public double Rating { get; set; }
    }
}
