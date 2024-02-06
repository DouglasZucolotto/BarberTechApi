using BarberTech.Application.Queries.Haircuts.Dtos;

namespace BarberTech.Application.Queries.Haircuts.GetAll
{
    public class GetHaircutsQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ImageSource { get; set; } = string.Empty;

        public IEnumerable<FeedbackDto> Feedbacks { get; set; } = Enumerable.Empty<FeedbackDto>();

        public double QntStars { get; set; }
    }
}
