using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BarberTech.Domain.Entities;
using NetTopologySuite.IO;
using NetTopologySuite;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class EstablishmentMapping : Mapping<Establishment>
    {
        public override void Configure(EntityTypeBuilder<Establishment> builder)
        {
            builder.ToTable("establishments");

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .IsRequired();

            builder.Property(e => e.Coordinates)
                .HasColumnName("coordinates")
                .HasColumnType("geometry (point)")
                .IsRequired();

            builder.Property(e => e.OpenTime)
                .HasColumnName("open_time")
                .IsRequired();

            builder.Property(e => e.LunchTime)
                .HasColumnName("lunch_time")
                .IsRequired();

            builder.Property(e => e.WorkInterval)
                .HasColumnName("work_interval")
                .IsRequired();

            builder.Property(e => e.LunchInterval)
                .HasColumnName("lunch_interval")
                .IsRequired();

            builder.HasMany(e => e.Feedbacks)
                .WithOne(f => f.Establishment);

            builder.HasMany(e => e.Barbers)
                .WithOne(b => b.Establishment);

            base.Configure(builder);
        }
    }
}
