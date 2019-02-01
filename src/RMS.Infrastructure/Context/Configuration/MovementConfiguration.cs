using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Infrastructure.Context.Configuration
{
    public class MovementConfiguraion : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("Movement");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Direction)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasOne(x => x.Flight)
                .WithMany()
                .HasForeignKey(x => x.FlightId);
        }
    }
}
