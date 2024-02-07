using BarberTech.Domain.Authentication;
using BarberTech.Domain.Entities;
using BarberTech.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BarberTech.Infraestructure.Authentication
{
    public class HttpContext : IHttpContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository; 

        public HttpContext(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserAsync()
        {
            var userId = GetPrivateUserId();
            return userId != Guid.Empty ? await _userRepository.GetByIdAsync(userId) : null;
        }

        public Guid GetUserId() => GetPrivateUserId();

        public bool? HasPermission(string permission)
        {
            return _httpContextAccessor?.HttpContext?.User
                .FindAll("permissions")
                .Select(permission => permission.Value)
                .Contains(permission);
        }

        private Guid GetPrivateUserId()
        {
            var userId = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId != null ? Guid.Parse(userId) : Guid.Empty;
        }
    }
}
