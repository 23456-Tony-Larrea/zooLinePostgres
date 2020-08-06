using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace prueba.Migrations
{
    public partial class fkTour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TourContinente",
                columns: table => new
                {
                    TourContienteId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TourId = table.Column<int>(nullable: false),
                    ContinenteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourContinente", x => x.TourContienteId);
                    table.ForeignKey(
                        name: "FK_TourContinente_Continente_ContinenteId",
                        column: x => x.ContinenteId,
                        principalTable: "Continente",
                        principalColumn: "ContinenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourContinente_Tour_TourId",
                        column: x => x.TourId,
                        principalTable: "Tour",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourContinente_ContinenteId",
                table: "TourContinente",
                column: "ContinenteId");

            migrationBuilder.CreateIndex(
                name: "IX_TourContinente_TourId",
                table: "TourContinente",
                column: "TourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourContinente");
        }
    }
}
