namespace BarberTech.Infraestructure.Entities
{
    public class Feedback
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string? Comment { get; set; }

        public int Qnt_stars { get; set; }

        public Guid HaircutId { get; set; }

        public Feedback(Guid id, Guid userId, string? comment, int qnt_stars, Guid haircutId)
        {
            Id = id;
            UserId = userId;
            Comment = comment;
            Qnt_stars = qnt_stars;
            HaircutId = haircutId;
        }
    }
}
