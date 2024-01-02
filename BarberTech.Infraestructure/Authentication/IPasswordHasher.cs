namespace BarberTech.Infraestructure.Authentication
{
    public interface IPasswordHasher
    {
        string Generate(string password);

        bool Verify(string passwordHash, string inputPassword);
    }
}
