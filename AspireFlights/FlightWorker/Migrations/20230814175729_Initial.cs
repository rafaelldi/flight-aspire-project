using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightWorker.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DepartureCity = table.Column<string>(type: "text", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArrivalCity = table.Column<string>(type: "text", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "DepartureCity", "DepartureTime", "ArrivalCity", "ArrivalTime" },
                values: new object[] { "AAA", "DFW", new DateTime(2023, 06, 04, 0, 0, 0, 0, DateTimeKind.Utc), "MUC", new DateTime(2023, 06, 05, 0, 0, 0, 0, DateTimeKind.Utc)});

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "DepartureCity", "DepartureTime", "ArrivalCity", "ArrivalTime" },
                values: new object[] { "BBB", "ATL", new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc), "DXB", new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Utc)});

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "DepartureCity", "DepartureTime", "ArrivalCity", "ArrivalTime" },
                values: new object[] { "CCC", "LHR", new DateTime(2023, 05, 01, 0, 0, 0, 0, DateTimeKind.Utc), "FRA", new DateTime(2023, 05, 02, 0, 0, 0, 0, DateTimeKind.Utc)});

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "DepartureCity", "DepartureTime", "ArrivalCity", "ArrivalTime" },
                values: new object[] { "DDD", "IST", new DateTime(2023, 08, 20, 0, 0, 0, 0, DateTimeKind.Utc), "AMS", new DateTime(2023, 08, 20, 0, 0, 0, 0, DateTimeKind.Utc)});

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "ATL", "Hartsfield–Jackson Atlanta International Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "DFW", "Dallas Fort Worth International Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "DEN", "Denver International Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "ORD", "O'Hare International Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "DXB", "Dubai International Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "LAX", "Los Angeles International Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "IST", "Istanbul Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "LHR", "Charles de Gaulle Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "DEL", "Indira Gandhi International Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "AMS", "Amsterdam Airport Schiphol" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "HND", "Tokyo Haneda Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "FRA", "Frankfurt Airport" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[] { "MUC", "Munich Airport" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Flights");
        }
    }
}
