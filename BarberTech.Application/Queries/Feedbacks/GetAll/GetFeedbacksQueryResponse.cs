namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQueryResponse
    {
        public Guid Id { get; set; }

        public string? Comment { get; set; }

        public double QntStarsAverage { get; set; }
        
        public string UserName { get; set; } = string.Empty;

        public DateTime At { get; set; }
    }
}
