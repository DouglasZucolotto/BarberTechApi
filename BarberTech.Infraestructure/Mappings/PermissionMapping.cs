using BarberTech.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class PermissionMapping : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("permissions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired();

            builder.Property(p => p.Name)
               .HasColumnName("name")
               .IsRequired();

            builder.Property(p => p.UserId)
               .HasColumnName("user_id")
               .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(u => u.Permissions)
                .HasForeignKey(p => p.UserId)
                .IsRequired();
        }
    }
}
