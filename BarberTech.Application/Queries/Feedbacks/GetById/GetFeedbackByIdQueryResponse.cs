namespace BarberTech.Application.Queries.Feedbacks.GetById
{
    public class GetFeedbackByIdQueryResponse
    {
        public Guid Id { get; set; }

        public string? Comment { get; set; }

        public int QntStars { get; set; }
    }
}

