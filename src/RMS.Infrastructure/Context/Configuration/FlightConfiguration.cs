using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Infrastructure.Context.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flight");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Departure)
                .IsRequired();

            builder.Property(x => x.Arrival)
                .IsRequired();

            builder.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId);

            builder.HasOne(x => x.TransportRoute)
                .WithMany()
                .HasForeignKey(x => x.TransportRouteId);

            builder.HasData(
                new Flight
                {
                    Id = 1,
                    MachineId = 1,
                    TransportRouteId = 1,
                    Departure = DateTime.Now,
                    Arrival = DateTime.Now.AddMinutes(10)
                });
        }
    }
}
