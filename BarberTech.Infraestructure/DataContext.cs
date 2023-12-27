using BarberTech.Infraestructure.Entities;
using BarberTech.Infraestructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure
{
    public class DataContext : DbContext
    {
        private readonly string ConnectionString = "Host=ep-plain-cherry-14588779-pooler.us-east-1.postgres.vercel-storage.com;Port=5432;Database=verceldb;Username=default;Password=nTswuZJGBb09;";

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Haircut> Haircuts { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Photo> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HaircutMapping());
            modelBuilder.ApplyConfiguration(new PhotoMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
        }
    }
}
