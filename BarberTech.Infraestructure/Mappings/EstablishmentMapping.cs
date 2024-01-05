using BarberTech.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class EstablishmentMapping : IEntityTypeConfiguration<Establishment>
    {
        public void Configure(EntityTypeBuilder<Establishment> builder)
        {
            builder.ToTable("establishments");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired();

            builder.Property(e => e.FeedbackId)
                .HasColumnName("feedback_id")
                .IsRequired();

            builder.Property(e => e.Address)
                .HasColumnName("address")
                .IsRequired();

            builder.Property(e => e.Coordinates)
                .HasColumnName("coordinates")
                .IsRequired();

            builder.Property(e => e.ImageSource)
                .HasColumnName("image_source")
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description");

            builder.Property(e => e.BusinessHours)
                .HasColumnName("business_hours");
        }
    }
}
