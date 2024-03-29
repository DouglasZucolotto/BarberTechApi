﻿using BarberTech.Domain.Entities;
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
                .WithMany(u => u.EventSchedules)
                .HasForeignKey(es => es.UserId);

            builder.Property(es => es.BarberId)
                .HasColumnName("barber_id")
                .IsRequired();

            builder.HasOne(es => es.Barber)
                .WithMany(b => b.EventSchedules)
                .HasForeignKey(es => es.BarberId);

            builder.Property(es => es.HaircutId)
                .HasColumnName("haircut_id")
                .IsRequired();

            builder.HasOne(es => es.Haircut)
                .WithMany(h => h.EventSchedules)
                .HasForeignKey(es => es.HaircutId);

            builder.Property(es => es.FeedbackId)
                .HasColumnName("feedback_id");

            builder.HasOne(es => es.Feedback)
                .WithOne(f => f.EventSchedule)
                .HasForeignKey<EventSchedule>(es => es.FeedbackId);

            builder.Property(es => es.Name)
               .HasColumnName("name")
               .IsRequired();

            builder.Property(es => es.DateTime)
              .HasColumnName("date_time")
              .IsRequired();

            builder.Property(es => es.EventStatus)
              .HasColumnName("event_status")
              .IsRequired();

            base.Configure(builder);
        }
    }
}
