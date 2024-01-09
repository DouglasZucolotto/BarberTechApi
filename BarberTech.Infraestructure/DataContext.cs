using BarberTech.Domain;
using BarberTech.Domain.Entities;
using BarberTech.Infraestructure.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BarberTech.Infraestructure
{
    public class DataContext : DbContext, IUnitOfWork
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string ConnectionString = "Host=ep-plain-cherry-14588779-pooler.us-east-1.postgres.vercel-storage.com;Port=5432;Database=verceldb;Username=default;Password=nTswuZJGBb09;";

        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString, x => x.UseNetTopologySuite(geographyAsDefault: true));
            //optionsBuilder.UseNpgsql(ConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Haircut> Haircuts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Establishment> Establishments { get; set; }
        
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Barber> Barbers { get; set; }

        public virtual async Task CommitAsync()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified)
                .Where(e => e.Entity is Entity);

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            foreach (var entry in modifiedEntries)
            {
                var entity = (Entity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                    entity.CreatedBy = userId != null ? Guid.Parse(userId) : Guid.Empty;
                }

                if (entry.State == EntityState.Modified)
                {
                    entity.CreatedAt = entity.CreatedAt.ToUniversalTime();
                }

                entity.ModifiedAt = DateTime.UtcNow;
                entity.ModifiedBy = userId != null ? Guid.Parse(userId) : Guid.Empty;
            }

            await SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HaircutMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new FeedbackMapping());
            modelBuilder.ApplyConfiguration(new EstablishmentMapping());
            modelBuilder.ApplyConfiguration(new PermissionMapping());
            modelBuilder.ApplyConfiguration(new BarberMapping());
        }
    }
}
