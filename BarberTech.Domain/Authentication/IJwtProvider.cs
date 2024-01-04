using BarberTech.Domain.Entities;

namespace BarberTech.Domain
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
