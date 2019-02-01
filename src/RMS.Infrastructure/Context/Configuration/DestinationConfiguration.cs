using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Infrastructure.Context.Configuration
{
    public class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.ToTable("Destination");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DestinationName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DestinationCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasData(
                new Destination { Id = 1, DestinationName = "SMT C07", DestinationCode = "DE1" },
                new Destination { Id = 2, DestinationName = "SMT C08", DestinationCode = "DE2" },
                new Destination { Id = 3, DestinationName = "SMT C09", DestinationCode = "DE3" });
        }
    }
}
