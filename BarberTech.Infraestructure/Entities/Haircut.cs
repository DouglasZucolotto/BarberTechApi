namespace BarberTech.Infraestructure.Entities
{
    public class Haircut
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string ImageSource { get; set; }

        public decimal Price { get; set; }

        public Haircut()
        {

        }

        public Haircut(string name, string description, string imageSource, decimal price)
        {
            Name = name;
            Description = description;
            ImageSource = imageSource;
            Price = price;
        }
    }
}
