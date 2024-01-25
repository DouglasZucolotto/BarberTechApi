using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Authentication
{
    public interface IHttpContext
    {
        Task<User?> GetUserAsync();

        Guid GetUserId();

        bool? HasPermission(string permission);
    }
}
