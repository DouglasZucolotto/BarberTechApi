using BarberTech.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class HaircutMapping : IEntityTypeConfiguration<Haircut>
    {
        public void Configure(EntityTypeBuilder<Haircut> builder)
        {
            builder.ToTable("haircuts");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired();

            builder.Property(h => h.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(h => h.Price)
                .HasColumnName("price")
                .IsRequired();

            builder.Property(h => h.Description)
                .HasColumnName("description");

            builder.Property(h => h.ImageSource)
                .HasColumnName("image_source")
                .IsRequired();
        }
    }
}
