using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RMS.Infrastructure.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DestinationName = table.Column<string>(maxLength: 50, nullable: false),
                    DestinationCode = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationName = table.Column<string>(maxLength: 50, nullable: false),
                    LocationCode = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Number = table.Column<string>(maxLength: 30, nullable: false),
                    IpAddress = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OriginName = table.Column<string>(maxLength: 50, nullable: false),
                    OriginCode = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusName = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportRoute",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OriginId = table.Column<int>(nullable: false),
                    DestinationId = table.Column<int>(nullable: false),
                    PathData = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportRoute_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportRoute_Origin_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MachineId = table.Column<int>(nullable: false),
                    TransportRouteId = table.Column<int>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flight_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_TransportRoute_TransportRouteId",
                        column: x => x.TransportRouteId,
                        principalTable: "TransportRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FlightId = table.Column<int>(nullable: false),
                    Direction = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movement_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "Id", "DestinationCode", "DestinationName" },
                values: new object[,]
                {
                    { 1, "DE1", "SMT C07" },
                    { 2, "DE2", "SMT C08" },
                    { 3, "DE3", "SMT C09" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "LocationCode", "LocationName" },
                values: new object[,]
                {
                    { 1, "X1", "Laser Room" },
                    { 2, "X2", "Material Room" },
                    { 3, "X3", "Kitting Room" },
                    { 4, "X4", "Production" }
                });

            migrationBuilder.InsertData(
                table: "Machine",
                columns: new[] { "Id", "IpAddress", "Name", "Number" },
                values: new object[] { 1, "11.11.11.11", "RD4", "001" });

            migrationBuilder.InsertData(
                table: "Origin",
                columns: new[] { "Id", "OriginCode", "OriginName" },
                values: new object[,]
                {
                    { 1, "OR1", "Laser Room 1" },
                    { 2, "OR2", "Laser Room 2" },
                    { 3, "OR3", "Laser Room 3" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Note", "StatusName" },
                values: new object[,]
                {
                    { 1, "Free", "Stop" },
                    { 2, "On the way", "Running" },
                    { 3, "Stop wait start", "Pause" },
                    { 4, "Wait request", "Wait" },
                    { 5, "Have problem", "Error" }
                });

            migrationBuilder.InsertData(
                table: "TransportRoute",
                columns: new[] { "Id", "DestinationId", "OriginId", "PathData" },
                values: new object[] { 1, 1, 1, "FDRFDLFDUPDRFDLFDU" });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "Id", "Arrival", "Departure", "MachineId", "TransportRouteId" },
                values: new object[] { 1, new DateTime(2019, 1, 30, 12, 12, 19, 209, DateTimeKind.Local).AddTicks(2779), new DateTime(2019, 1, 30, 12, 2, 19, 209, DateTimeKind.Local).AddTicks(1532), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_MachineId",
                table: "Flight",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_TransportRouteId",
                table: "Flight",
                column: "TransportRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_FlightId",
                table: "Movement",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRoute_DestinationId",
                table: "TransportRoute",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportRoute_OriginId",
                table: "TransportRoute",
                column: "OriginId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Movement");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "TransportRoute");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Origin");
        }
    }
}
