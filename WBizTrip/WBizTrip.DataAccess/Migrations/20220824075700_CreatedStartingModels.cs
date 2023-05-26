using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WBizTrip.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreatedStartingModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clients",
                newName: "ClientId");

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FlightBudget = table.Column<int>(type: "int", nullable: false),
                    FoodBudget = table.Column<int>(type: "int", nullable: false),
                    PublicTransportBudget = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 1,
                columns: new[] { "Address", "AnnualBudget", "Name", "PhoneNumber", "TeamLeader" },
                values: new object[] { "Hasdeu 1", 10000f, "Universitatea Babes Bolyai", "0711111111", null });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Address", "AnnualBudget", "Name", "PhoneNumber", "TeamLeader" },
                values: new object[] { 2, "Observatory street 1", 10000.99f, "Universitatea Politehnica", "0722222222", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "mircea.gabriel@gmail.com", "Gabriel Mircea", "passwordmircea", 2 },
                    { 2, "ivanmircea06@gmail.ro", "Mircea Ivan", "passwordivan", 2 },
                    { 3, "dmoga@yahoo.com", "Dani Moga", "passwordmoga", 0 },
                    { 4, "danielalupea1975@hotmail.com", "Daniela Lupea", "passwordlupea", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ClientId",
                keyValue: 2);

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Clients",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "AnnualBudget", "Name", "PhoneNumber", "TeamLeader" },
                values: new object[] { "Main Road 1", 9999f, "Google", "0798984937", "Mihai" });
        }
    }
}
