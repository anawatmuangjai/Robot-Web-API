using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Infrastructure.Context.Configuration
{
    public class OriginConfiguration : IEntityTypeConfiguration<Origin>
    {
        public void Configure(EntityTypeBuilder<Origin> builder)
        {
            builder.ToTable("Origin");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OriginName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.OriginCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasData(
                new Origin { Id = 1, OriginName = "Laser Room 1", OriginCode = "OR1" },
                new Origin { Id = 2, OriginName = "Laser Room 2", OriginCode = "OR2" },
                new Origin { Id = 3, OriginName = "Laser Room 3", OriginCode = "OR3" });
        }
    }
}
