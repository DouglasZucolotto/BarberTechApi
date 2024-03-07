namespace BarberTech.Application.Queries.Feedbacks.GetAll
{
    public class GetFeedbacksQueryResponse
    {
        public Guid Id { get; set; }

        public string? Comment { get; set; }

        public double RatingAverage { get; set; }
        
        public string UserName { get; set; } = string.Empty;

        public string BarberName { get; set; } = string.Empty;

        public string HaircutName { get; set; } = string.Empty;

        public string EstablishmentAddress { get; set; } = string.Empty;

        public string At { get; set; } = string.Empty;
    }
}
