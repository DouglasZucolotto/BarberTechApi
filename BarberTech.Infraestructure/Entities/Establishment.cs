using BarberTech.Infraestructure.Entities;

namespace BarberTech.Infraestructure.Entities
{
    public class Establishment
    {  
        public Guid Id { get; set; }

        public Guid FeedbackId { get; set; }

        public string Address { get; set; }

        public string Coordinates { get; set; }

        public string ImageSource { get; set; }

        public string? Description { get; set; }

        public string BusinessHours { get; set; }

        public Establishment(Guid id, Guid feedbackId, string address, string coordinates, string imageSource, string? description, string businessHours)
        {
            Id = id;
            FeedbackId = feedbackId;
            Address = address;
            Coordinates = coordinates;
            ImageSource = imageSource;
            Description = description;
            BusinessHours = businessHours;
        }
    }
}
