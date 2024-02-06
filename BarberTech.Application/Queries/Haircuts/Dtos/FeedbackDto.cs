namespace BarberTech.Application.Queries.Haircuts.Dtos
{
    public class FeedbackDto
    {
        public int QntStars { get; set; }

        public string? Comment { get; set; }

        public UserDto User { get; set; }

        public DateTime At { get; set; }
    }
}
