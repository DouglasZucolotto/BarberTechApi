using BarberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class HaircutMapping : Mapping<Haircut>
    {
        public override void Configure(EntityTypeBuilder<Haircut> builder)
        {
            builder.ToTable("haircuts");

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

            builder.HasMany(h => h.Feedbacks)
                .WithOne(f => f.Haircut);

            base.Configure(builder);
        }
    }
}
