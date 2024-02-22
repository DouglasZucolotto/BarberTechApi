using BarberTech.Domain.Entities;

namespace BarberTech.Domain.Authentication
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
