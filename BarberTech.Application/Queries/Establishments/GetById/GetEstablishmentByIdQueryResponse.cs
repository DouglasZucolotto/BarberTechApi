namespace BarberTech.Application.Queries.Establishments.GetById
{
    public class GetEstablishmentByIdQueryResponse
    {
        public Guid Id { get; set; }

        public Guid FeedbackId { get; set; }

        public string Address { get; set; }

        public string Coordinates { get; set; }

        public string ImageSource { get; set; }

        public string? Description { get; set; }

        public string BusinessHours { get; set; }
    }
}

