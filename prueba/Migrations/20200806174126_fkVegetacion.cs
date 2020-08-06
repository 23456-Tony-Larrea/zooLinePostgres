using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace prueba.Migrations
{
    public partial class fkVegetacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClimaVegetacion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    climaId = table.Column<int>(nullable: false),
                    VegetacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimaVegetacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimaVegetacion_Vegetacion_VegetacionId",
                        column: x => x.VegetacionId,
                        principalTable: "Vegetacion",
                        principalColumn: "VegetacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClimaVegetacion_Clima_climaId",
                        column: x => x.climaId,
                        principalTable: "Clima",
                        principalColumn: "ClimaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClimaVegetacion_VegetacionId",
                table: "ClimaVegetacion",
                column: "VegetacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimaVegetacion_climaId",
                table: "ClimaVegetacion",
                column: "climaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClimaVegetacion");
        }
    }
}
