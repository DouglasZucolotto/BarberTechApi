using BarberTech.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class PhotoMapping : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("photos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired();

            builder.Property(p => p.File)
                .HasColumnName("file")
                .IsRequired();
        }
    }
}
