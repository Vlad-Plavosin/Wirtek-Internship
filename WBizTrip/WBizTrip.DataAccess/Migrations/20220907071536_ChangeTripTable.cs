using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBizTrip.DataAccess.Migrations
{
    public partial class ChangeTripTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "PublicTransportBudget",
                table: "Trips",
                newName: "TrainPassengers");

            migrationBuilder.RenameColumn(
                name: "FoodBudget",
                table: "Trips",
                newName: "FlightPassengers");

            migrationBuilder.RenameColumn(
                name: "FlightBudget",
                table: "Trips",
                newName: "CarPassengers");

            migrationBuilder.AddColumn<int>(
                name: "BusPassengers",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusPassengers",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TrainPassengers",
                table: "Trips",
                newName: "PublicTransportBudget");

            migrationBuilder.RenameColumn(
                name: "FlightPassengers",
                table: "Trips",
                newName: "FoodBudget");

            migrationBuilder.RenameColumn(
                name: "CarPassengers",
                table: "Trips",
                newName: "FlightBudget");

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportType = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Name", "TransportType", "TripId" },
                values: new object[] { 1, "Denisa Vamvu", 1, 3 });
        }
    }
}
