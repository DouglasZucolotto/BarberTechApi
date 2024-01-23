using BarberTech.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class EventScheduleMapping : Mapping<EventSchedule>
    {
        public override void Configure(EntityTypeBuilder<EventSchedule> builder)
        {
            builder.ToTable("event_schedules");

            builder.Property(es => es.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.HasOne(es => es.User)
                .WithOne(u => u.EventSchedule)
                .HasForeignKey<EventSchedule>(es => es.UserId);

            builder.Property(es => es.BarberId)
                .HasColumnName("barber_id")
                .IsRequired();

            builder.HasOne(es => es.Barber)
                .WithMany(b => b.EventSchedules)
                .HasForeignKey(es => es.BarberId);

            builder.Property(es => es.EstablishmentId)
               .HasColumnName("establishment_id")
               .IsRequired();

            builder.HasOne(es => es.Establishment)
                .WithMany(e => e.EventSchedules)
                .HasForeignKey(es => es.EstablishmentId);

            builder.Property(es => es.Name)
               .HasColumnName("name")
               .IsRequired();

            builder.Property(es => es.DateTime)
              .HasColumnName("date_time")
              .IsRequired();

            base.Configure(builder);
        }
    }
}
