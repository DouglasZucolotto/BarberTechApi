using Microsoft.AspNetCore.Authorization;

namespace BarberTech.Infraestructure.Authentication
{
    public sealed class HasPermissionAttribute : AuthorizeAttribute
    {
        public HasPermissionAttribute(string permission) : base(policy: permission)
        {
        }
    }
}
