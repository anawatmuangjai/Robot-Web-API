﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RMS.Infrastructure.Context;

namespace RMS.Infrastructure.Migrations
{
    [DbContext(typeof(RobotContext))]
    [Migration("20190130050220_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RMS.Core.Entities.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DestinationCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("DestinationName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Destination");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DestinationCode = "DE1",
                            DestinationName = "SMT C07"
                        },
                        new
                        {
                            Id = 2,
                            DestinationCode = "DE2",
                            DestinationName = "SMT C08"
                        },
                        new
                        {
                            Id = 3,
                            DestinationCode = "DE3",
                            DestinationName = "SMT C09"
                        });
                });

            modelBuilder.Entity("RMS.Core.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Arrival");

                    b.Property<DateTime>("Departure");

                    b.Property<int>("MachineId");

                    b.Property<int>("TransportRouteId");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("TransportRouteId");

                    b.ToTable("Flight");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Arrival = new DateTime(2019, 1, 30, 12, 12, 19, 209, DateTimeKind.Local).AddTicks(2779),
                            Departure = new DateTime(2019, 1, 30, 12, 2, 19, 209, DateTimeKind.Local).AddTicks(1532),
                            MachineId = 1,
                            TransportRouteId = 1
                        });
                });

            modelBuilder.Entity("RMS.Core.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Location");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationCode = "X1",
                            LocationName = "Laser Room"
                        },
                        new
                        {
                            Id = 2,
                            LocationCode = "X2",
                            LocationName = "Material Room"
                        },
                        new
                        {
                            Id = 3,
                            LocationCode = "X3",
                            LocationName = "Kitting Room"
                        },
                        new
                        {
                            Id = 4,
                            LocationCode = "X4",
                            LocationName = "Production"
                        });
                });

            modelBuilder.Entity("RMS.Core.Entities.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Machine");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IpAddress = "11.11.11.11",
                            Name = "RD4",
                            Number = "001"
                        });
                });

            modelBuilder.Entity("RMS.Core.Entities.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Direction")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("FlightId");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Movement");
                });

            modelBuilder.Entity("RMS.Core.Entities.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OriginCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("OriginName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Origin");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OriginCode = "OR1",
                            OriginName = "Laser Room 1"
                        },
                        new
                        {
                            Id = 2,
                            OriginCode = "OR2",
                            OriginName = "Laser Room 2"
                        },
                        new
                        {
                            Id = 3,
                            OriginCode = "OR3",
                            OriginName = "Laser Room 3"
                        });
                });

            modelBuilder.Entity("RMS.Core.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Note")
                        .HasMaxLength(100);

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Status");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Note = "Free",
                            StatusName = "Stop"
                        },
                        new
                        {
                            Id = 2,
                            Note = "On the way",
                            StatusName = "Running"
                        },
                        new
                        {
                            Id = 3,
                            Note = "Stop wait start",
                            StatusName = "Pause"
                        },
                        new
                        {
                            Id = 4,
                            Note = "Wait request",
                            StatusName = "Wait"
                        },
                        new
                        {
                            Id = 5,
                            Note = "Have problem",
                            StatusName = "Error"
                        });
                });

            modelBuilder.Entity("RMS.Core.Entities.TransportRoute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DestinationId");

                    b.Property<int>("OriginId");

                    b.Property<string>("PathData")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OriginId");

                    b.ToTable("TransportRoute");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DestinationId = 1,
                            OriginId = 1,
                            PathData = "FDRFDLFDUPDRFDLFDU"
                        });
                });

            modelBuilder.Entity("RMS.Core.Entities.Flight", b =>
                {
                    b.HasOne("RMS.Core.Entities.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RMS.Core.Entities.TransportRoute", "TransportRoute")
                        .WithMany()
                        .HasForeignKey("TransportRouteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RMS.Core.Entities.Movement", b =>
                {
                    b.HasOne("RMS.Core.Entities.Flight", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RMS.Core.Entities.TransportRoute", b =>
                {
                    b.HasOne("RMS.Core.Entities.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RMS.Core.Entities.Origin", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}