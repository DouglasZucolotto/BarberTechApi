using NetTopologySuite.Geometries;

namespace BarberTech.Domain.Entities
{
    public class Establishment : Entity
    {
        public string Address { get; set; }

        public Point Coordinates { get; set; }

        public string ImageSource { get; set; }

        public string? Description { get; set; }

        public string BusinessHours { get; set; }

        public ICollection<Feedback> Feedbacks { get; set; }

        public Establishment()
        {
        }

        public Establishment(string address, Point coordinates, string imageSource, string? description, string businessHours)
        {
            Address = address;
            Coordinates = coordinates;
            ImageSource = imageSource;
            Description = description;
            BusinessHours = businessHours;
        }
    }
}
