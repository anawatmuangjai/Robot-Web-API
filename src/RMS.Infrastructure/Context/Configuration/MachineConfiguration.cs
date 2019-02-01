using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Infrastructure.Context.Configuration
{
    public class MachineConfiguration : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.ToTable("Machine");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(x => x.IpAddress)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasData(new Machine()
            {
                Id = 1,
                Name = "RD4",
                Number = "001",
                IpAddress = "11.11.11.11"
            });
        }
    }
}
