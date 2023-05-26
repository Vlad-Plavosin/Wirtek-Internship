using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBizTrip.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tripforeignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ClientId",
                table: "Trips",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Clients_ClientId",
                table: "Trips",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Clients_ClientId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_ClientId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Trips");
        }
    }
}
