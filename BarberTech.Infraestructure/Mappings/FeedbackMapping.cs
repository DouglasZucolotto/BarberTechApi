using BarberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class FeedbackMapping : Mapping<Feedback>
    {
        public override void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("feedbacks");

            builder.Property(f => f.UserId)
                .HasColumnName("user_id");

            builder.HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId)
                .IsRequired();

            builder.Property(f => f.Comment)
                .HasColumnName("comment");

            builder.Property(f => f.QntStars)
                .HasColumnName("qnt_stars")
                .IsRequired();

            builder.Property(f => f.HaircutId)
                .HasColumnName("haircut_id");

            builder.HasOne(f => f.Haircut)
                .WithMany(h => h.Feedbacks)
                .HasForeignKey(f => f.HaircutId);

            builder.Property(f => f.BarberId)
                .HasColumnName("barber_id");

            builder.HasOne(f => f.Barber)
                .WithMany(b => b.Feedbacks)
                .HasForeignKey(f => f.BarberId);

            builder.Property(f => f.EstablishmentId)
                .HasColumnName("establishment_id");

            builder.HasOne(f => f.Establishment)
                .WithMany(e => e.Feedbacks)
                .HasForeignKey(f => f.EstablishmentId);

            base.Configure(builder);
        }
    }
}
