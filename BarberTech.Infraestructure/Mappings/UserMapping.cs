﻿using BarberTech.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberTech.Infraestructure.Mappings
{
    internal sealed class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .HasValueGenerator<GuidValueGenerator>()
                .IsRequired();

            builder.Property(u => u.Name)
               .HasColumnName("name")
               .IsRequired();

            builder.Property(u => u.Email)
               .HasColumnName("email")
               .IsRequired();

            builder.Property(u => u.Password)
               .HasColumnName("password")
               .IsRequired();
        }
    }
}