using BarberTech.Application.Queries.Barbers.Dtos;

namespace BarberTech.Application.Queries.Barbers.GetAll
{
    public class GetBarbersQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Contact { get; set; } = string.Empty;

        public string? About { get; set; }

        public string? ImageSource { get; set; }

        public double Rating { get; set; }

        public SocialDto Social { get; set; } = new SocialDto();
    }
}
