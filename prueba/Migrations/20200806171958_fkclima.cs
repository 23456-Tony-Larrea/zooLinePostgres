using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace prueba.Migrations
{
    public partial class fkclima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HabitatClima",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HabitatId = table.Column<int>(nullable: false),
                    climaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitatClima", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitatClima_Habitat_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitat",
                        principalColumn: "HabitatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitatClima_Clima_climaId",
                        column: x => x.climaId,
                        principalTable: "Clima",
                        principalColumn: "ClimaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitatClima_HabitatId",
                table: "HabitatClima",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitatClima_climaId",
                table: "HabitatClima",
                column: "climaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitatClima");
        }
    }
}
