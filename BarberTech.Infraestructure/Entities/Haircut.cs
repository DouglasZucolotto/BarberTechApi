namespace BarberTech.Infraestructure.Entities
{
    public class Haircut
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public Guid PhotoId { get; set; }

        public Photo Photo { get; set; }

        public decimal Price { get; set; }

        public Haircut()
        {

        }

        public Haircut(string name, string description, Photo photo, decimal price)
        {
            Name = name;
            Description = description;
            Photo = photo;
            Price = price;
        }
    }
}
