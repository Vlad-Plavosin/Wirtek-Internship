using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBizTrip.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CreateTeamLeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamLeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamLeaders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { 5, "teamleader@hotmail.com", "testing", "passwordteamleader", 1 });

            migrationBuilder.InsertData(
                table: "TeamLeaders",
                columns: new[] { "Id", "Team", "UserId" },
                values: new object[] { 1, "Team 1", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_TeamLeaders_UserId",
                table: "TeamLeaders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamLeaders");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
