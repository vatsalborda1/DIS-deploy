using Microsoft.EntityFrameworkCore.Migrations;

namespace FBIApplication.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParticipationModel",
                columns: table => new
                {
                    ParticipationModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipationModel", x => x.ParticipationModelId);
                });

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    data_year = table.Column<int>(type: "int", nullable: false),
                    population = table.Column<int>(type: "int", nullable: false),
                    total_agency_count = table.Column<int>(type: "int", nullable: false),
                    published_agency_count = table.Column<int>(type: "int", nullable: false),
                    active_agency_count = table.Column<int>(type: "int", nullable: false),
                    covered_agency_count = table.Column<int>(type: "int", nullable: false),
                    population_covered = table.Column<int>(type: "int", nullable: false),
                    agency_count_nibrs_submitting = table.Column<int>(type: "int", nullable: false),
                    agency_count_leoka_submitting = table.Column<int>(type: "int", nullable: false),
                    agency_count_pe_submitting = table.Column<int>(type: "int", nullable: false),
                    agency_count_srs_submitting = table.Column<int>(type: "int", nullable: false),
                    agency_count_asr_submitting = table.Column<int>(type: "int", nullable: false),
                    agency_count_hc_submitting = table.Column<int>(type: "int", nullable: false),
                    agency_count_supp_submitting = table.Column<int>(type: "int", nullable: false),
                    nibrs_population_covered = table.Column<int>(type: "int", nullable: false),
                    total_population = table.Column<int>(type: "int", nullable: false),
                    csv_header = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nibrs_population_percentage_covered = table.Column<double>(type: "float", nullable: false),
                    ParticipationModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_Result_ParticipationModel_ParticipationModelId",
                        column: x => x.ParticipationModelId,
                        principalTable: "ParticipationModel",
                        principalColumn: "ParticipationModelId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_ParticipationModelId",
                table: "Result",
                column: "ParticipationModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropTable(
                name: "ParticipationModel");
        }
    }
}
