namespace BarberTech.Application.Queries.EventSchedules.GetAll
{
    public class GetSchedulesQueryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string BarberName { get; set; } = string.Empty;

        public string HaircutName { get; set; } = string.Empty;
         
        public string Date { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
