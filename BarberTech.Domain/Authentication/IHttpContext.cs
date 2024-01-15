namespace BarberTech.Domain.Authentication
{
    public interface IHttpContext
    {
        Guid GetUserId();

        bool HasPermission(string permission);
    }
}
