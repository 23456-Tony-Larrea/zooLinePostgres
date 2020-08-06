using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace prueba.Migrations
{
    public partial class fkHabitat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EcosistemaHabitat",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EcosistemaId = table.Column<int>(nullable: false),
                    HabitatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EcosistemaHabitat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EcosistemaHabitat_Ecosistema_EcosistemaId",
                        column: x => x.EcosistemaId,
                        principalTable: "Ecosistema",
                        principalColumn: "EcosistemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EcosistemaHabitat_Habitat_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitat",
                        principalColumn: "HabitatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaHabitat_EcosistemaId",
                table: "EcosistemaHabitat",
                column: "EcosistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_EcosistemaHabitat_HabitatId",
                table: "EcosistemaHabitat",
                column: "HabitatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EcosistemaHabitat");
        }
    }
}
