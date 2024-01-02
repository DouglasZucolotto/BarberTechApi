using BarberTech.Infraestructure.Entities;

namespace BarberTech.Infraestructure
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
