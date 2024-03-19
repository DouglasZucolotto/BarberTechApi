namespace BarberTech.Application.Queries.Users.Dtos
{
    public class HaircutDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ImageSource { get; set; } = string.Empty;
    }
}
