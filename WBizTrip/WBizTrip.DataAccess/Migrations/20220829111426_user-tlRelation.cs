using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBizTrip.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class usertlRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamLeaders_UserId",
                table: "TeamLeaders");

            migrationBuilder.DeleteData(
                table: "TeamLeaders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "TeamLeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamLeaders_UserId",
                table: "TeamLeaders",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamLeaders_UserId",
                table: "TeamLeaders");

            migrationBuilder.DropColumn(
                name: "Client",
                table: "TeamLeaders");

            migrationBuilder.InsertData(
                table: "TeamLeaders",
                columns: new[] { "Id", "Team", "UserId" },
                values: new object[] { 1, "Team 1", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_TeamLeaders_UserId",
                table: "TeamLeaders",
                column: "UserId");
        }
    }
}
