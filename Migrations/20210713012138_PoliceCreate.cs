using Microsoft.EntityFrameworkCore.Migrations;

namespace FBIApplication.Migrations
{
    public partial class PoliceCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoliceModel",
                columns: table => new
                {
                    PoliceModelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_year = table.Column<int>(type: "int", nullable: false),
                    population = table.Column<int>(type: "int", nullable: false),
                    officer_count = table.Column<int>(type: "int", nullable: false),
                    officer_rate_per_1000 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceModel", x => x.PoliceModelID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliceModel");
        }
    }
}
