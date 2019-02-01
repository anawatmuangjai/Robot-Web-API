using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Infrastructure.Context.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("Location");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.LocationName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LocationCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasData(
                new Location() { Id = 1, LocationName = "Laser Room", LocationCode = "X1" },
                new Location() { Id = 2, LocationName = "Material Room", LocationCode = "X2" },
                new Location() { Id = 3, LocationName = "Kitting Room", LocationCode = "X3" },
                new Location() { Id = 4, LocationName = "Production", LocationCode = "X4" });
        }
    }
}
