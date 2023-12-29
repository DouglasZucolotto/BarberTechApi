namespace BarberTech.Application.Queries.Haircuts.GetById
{
    public class GetHaircutByIdQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ImageSource { get; set; }
    }
}
