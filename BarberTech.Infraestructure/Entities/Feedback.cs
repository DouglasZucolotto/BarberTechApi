namespace BarberTech.Infraestructure.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? Comment { get; set; }

        public int Qnt_stars { get; set; }

        public Guid FeedbackId { get; set; }

        public Feedback(Guid userId, string comment, int qnt_stars, Guid feedbackId)
        {
            UserId = userId;
            Comment = comment;
            Qnt_stars = qnt_stars;
            FeedbackId = feedbackId;
        }
    }
}
