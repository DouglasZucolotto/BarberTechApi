namespace BarberTech.Application.Queries.Feedbacks.GetById
{
    public class GetFeedbackByIdQueryResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Comment { get; set; }

        public int Qnt_stars { get; set; }

        public Guid HaircutId { get; set; }
    }
}

