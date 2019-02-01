using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RMS.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Infrastructure.Context.Configuration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.StatusName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Note)
                .HasMaxLength(100);

            builder.HasData(
                new Status() { Id = 1, StatusName = "Stop", Note = "Free" },
                new Status() { Id = 2, StatusName = "Running", Note = "On the way" },
                new Status() { Id = 3, StatusName = "Pause", Note = "Stop wait start" },
                new Status() { Id = 4, StatusName = "Wait", Note = "Wait request" },
                new Status() { Id = 5, StatusName = "Error", Note = "Have problem" });
        }
    }
}
