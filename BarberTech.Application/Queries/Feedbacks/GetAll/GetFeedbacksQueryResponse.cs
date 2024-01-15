namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQueryResponse
    {
        public Guid Id { get; set; }

        public string? Comment { get; set; }

        public int QntStars { get; set; }

        public Guid EstablishmentId { get; set; }

        public Guid HaircutId { get; set; }

        public Guid BarberId { get; set; }
    }
}

