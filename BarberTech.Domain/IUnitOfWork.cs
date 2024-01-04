namespace BarberTech.Domain
{
    public interface IUnitOfWork
    {
        public Task CommitAsync();
    }
}
