using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBizTrip.DataAccess.Migrations
{
    public partial class foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Clients_ClientId",
                table: "Trips");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Client",
                table: "TeamLeaders");

            migrationBuilder.DropColumn(
                name: "TeamLeader",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Trips",
                newName: "TeamLeader");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_ClientId",
                table: "Trips",
                newName: "IX_Trips_TeamLeader");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "TeamLeaderId",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripSuggestions_TripId",
                table: "TripSuggestions",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TeamLeaderId",
                table: "Clients",
                column: "TeamLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_TeamLeaders_TeamLeaderId",
                table: "Clients",
                column: "TeamLeaderId",
                principalTable: "TeamLeaders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Clients_TeamLeader",
                table: "Trips",
                column: "TeamLeader",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripSuggestions_Trips_TripId",
                table: "TripSuggestions",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_TeamLeaders_TeamLeaderId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Clients_TeamLeader",
                table: "Trips");

            migrationBuilder.DropForeignKey(
                name: "FK_TripSuggestions_Trips_TripId",
                table: "TripSuggestions");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TripSuggestions_TripId",
                table: "TripSuggestions");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TeamLeaderId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TeamLeaderId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "TeamLeader",
                table: "Trips",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Trips_TeamLeader",
                table: "Trips",
                newName: "IX_Trips_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "TeamLeaders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamLeader",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "Role" },
                values: new object[] { 5, "teamleader@hotmail.com", "testing", "passwordteamleader", 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Clients_ClientId",
                table: "Trips",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
