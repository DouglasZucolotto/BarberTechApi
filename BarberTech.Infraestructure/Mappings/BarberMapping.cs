using BarberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class BarberMapping : Mapping<Barber>
    {
        public override void Configure(EntityTypeBuilder<Barber> builder)
        {
            builder.ToTable("barbers");

            builder.Property(b => b.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithOne(u => u.Barber)
                .HasForeignKey<Barber>(b => b.UserId);

            builder.Property(b => b.About)
                .HasColumnName("about");

            builder.Property(b => b.Contact)
                .HasColumnName("contact")
                .IsRequired();

            builder.Property(b => b.Facebook)
                .HasColumnName("facebook");

            builder.Property(b => b.Instagram)
                .HasColumnName("instagram");

            builder.Property(b => b.Twitter)
               .HasColumnName("twitter");

            builder.Property(b => b.EstablishmentId)
                .HasColumnName("establishment_id");

            builder.HasOne(b => b.Establishment)
                .WithMany(e => e.Barbers)
                .HasForeignKey(b => b.EstablishmentId);

            builder.HasMany(b => b.Feedbacks)
                .WithOne(f => f.Barber);

            builder.HasMany(b => b.EventSchedules)
                .WithOne(es => es.Barber);

            base.Configure(builder);
        }
    }
}
