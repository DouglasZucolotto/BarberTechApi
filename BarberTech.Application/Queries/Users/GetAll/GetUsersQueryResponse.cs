namespace BarberTech.Application.Queries.Users.GetAll
{
    public class GetUsersQueryResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? ImageSource { get; set; }
    }
}
