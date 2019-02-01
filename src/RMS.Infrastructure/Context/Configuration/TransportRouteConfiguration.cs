using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Infrastructure.Context.Configuration
{
    public class TransportRouteConfiguration : IEntityTypeConfiguration<TransportRoute>
    {
        public void Configure(EntityTypeBuilder<TransportRoute> builder)
        {
            builder.ToTable("TransportRoute");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PathData)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Origin)
                .WithMany()
                .HasForeignKey(x => x.OriginId);

            builder.HasOne(x => x.Destination)
                .WithMany()
                .HasForeignKey(x => x.DestinationId);

            builder.HasData(
                new TransportRoute
                {
                    Id = 1,
                    OriginId = 1,
                    DestinationId = 1,
                    PathData = "FDRFDLFDUPDRFDLFDU"
                });
        }
    }
}
