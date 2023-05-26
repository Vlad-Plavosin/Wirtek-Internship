using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBizTrip.DataAccess.Migrations
{
    public partial class CreateTripSuggestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripSuggestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransportInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransportBudget = table.Column<int>(type: "int", nullable: false),
                    AccommodationInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccommodationBudget = table.Column<int>(type: "int", nullable: false),
                    FoodBudget = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripSuggestions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TripSuggestions");
        }
    }
}
