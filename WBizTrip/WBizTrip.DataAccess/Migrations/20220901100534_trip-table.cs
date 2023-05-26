using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBizTrip.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class triptable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Transport",
                table: "TeamMembers",
                newName: "TransportType");

            migrationBuilder.AddColumn<int>(
                name: "LocalTransportType",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalTransportType",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TransportType",
                table: "TeamMembers",
                newName: "Transport");
        }
    }
}
