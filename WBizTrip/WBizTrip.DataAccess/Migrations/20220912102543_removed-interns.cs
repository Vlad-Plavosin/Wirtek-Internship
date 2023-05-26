using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WBizTrip.DataAccess.Migrations
{
    public partial class removedinterns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interns");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interns", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Interns",
                columns: new[] { "Id", "Age", "Name" },
                values: new object[] { 1, 23, "Denisa Vamvu" });
        }
    }
}
