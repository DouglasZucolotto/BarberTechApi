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

                entity.ModifiedAt = DateTime.UtcNow;
                entity.ModifiedBy = userIdConverted;

                ConvertDatesToUtc(entity);
            }

            await SaveChangesAsync();
        }

        private void ConvertDatesToUtc(Entity entity)
        {
            var properties = entity.GetType().GetProperties()
                .Where(prop => prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?));

            foreach (var prop in properties)
            {
                var value = (DateTime?)prop.GetValue(entity);

                if (value != null)
                {
                    prop.SetValue(entity, value.Value.ToUniversalTime());
                }
            }
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
