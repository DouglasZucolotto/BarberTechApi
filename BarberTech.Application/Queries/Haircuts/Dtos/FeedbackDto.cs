namespace BarberTech.Application.Queries.Haircuts.Dtos
{
    public class FeedbackDto
    {
        public int QntStars { get; set; }

        public string? Comment { get; set; }

        public string UserName { get; set; } = string.Empty;

        public DateTime At { get; set; }
    }
}
