using BarberTech.Domain;
using BarberTech.Domain.Entities;
using BarberTech.Infraestructure.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace BarberTech.Infraestructure
{
    public class DataContext : DbContext, IUnitOfWork
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ConnectionOptions _connectionOptions;

        public DataContext(
            DbContextOptions<DataContext> options,
            IHttpContextAccessor httpContextAccessor,
            IOptions<ConnectionOptions> connectionOptions) 
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            _connectionOptions = connectionOptions.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionOptions.DefaultConnection, x => x.UseNetTopologySuite(geographyAsDefault: true));
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Haircut> Haircuts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Establishment> Establishments { get; set; }
        
        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Barber> Barbers { get; set; }

        public DbSet<EventSchedule> EventSchedules { get; set; }


        public virtual async Task CommitAsync()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State is EntityState.Added or EntityState.Modified)
                .Where(e => e.Entity is Entity);

            var userId = _httpContextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userIdConverted = userId != null ? Guid.Parse(userId) : Guid.Empty;

            foreach (var entry in modifiedEntries)
            {
                var entity = (Entity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedAt = DateTime.UtcNow;
                    entity.CreatedBy = userIdConverted;
                }

                if (entry.State == EntityState.Modified)
                {
                    entity.CreatedAt = entity.CreatedAt.ToUniversalTime();
                }

                entity.ModifiedAt = DateTime.UtcNow;
                entity.ModifiedBy = userIdConverted;
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
            modelBuilder.ApplyConfiguration(new EventScheduleMapping());
        }
    }
}
