using BarberTech.Domain.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BarberTech.Infraestructure.Authentication
{
    public class HttpContext : IHttpContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetUserId()
        {
            var userId = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.Parse(userId);
        }

        public bool HasPermission(string permission)
        {
            var permissions = _httpContextAccessor?.HttpContext?.User
                .FindAll("permissions")
                .Select(permission => permission.Value);

            return permissions.Contains(permission);
        }
    }
}
