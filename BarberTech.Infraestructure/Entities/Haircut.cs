namespace BarberTech.Infraestructure.Entities
{
    public class Haircut
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string PhotoURL { get; set; }

        public decimal Price { get; set; }

        public Haircut(string name, string description, string photoURL, decimal price)
        {
            Name = name;
            Description = description;
            PhotoURL = photoURL;
            Price = price;
        }
    }
}
