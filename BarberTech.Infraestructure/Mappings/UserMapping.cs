using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BarberTech.Domain.Entities;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class UserMapping : Mapping<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.Property(u => u.Email)
               .HasColumnName("email")
               .IsRequired();

            builder.Property(u => u.Password)
               .HasColumnName("password")
               .IsRequired();

            builder.Property(u => u.Name)
               .HasColumnName("name")
               .IsRequired();

            builder.Property(u => u.ImageSource)
               .HasColumnName("image_source");

            builder.HasMany(u => u.Permissions)
                .WithOne(p => p.User);

            builder.HasOne(u => u.Barber)
                .WithOne(b => b.User);

            builder.HasOne(u => u.EventSchedule)
                .WithOne(es => es.User);

            base.Configure(builder);
        }
    }
}
