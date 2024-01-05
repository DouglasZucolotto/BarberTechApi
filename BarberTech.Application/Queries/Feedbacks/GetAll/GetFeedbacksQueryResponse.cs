namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQueryResponse
    {
        public Guid Id { get; set; }

        public string? Comment { get; set; }

        public int QntStars { get; set; }
    }
}

