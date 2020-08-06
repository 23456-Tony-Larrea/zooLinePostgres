using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace prueba.Migrations
{
    public partial class fkContinente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContinenteEcosistema",
                columns: table => new
                {
                    ContinenteEcosistemaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContinenteId = table.Column<int>(nullable: false),
                    EcosistemaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinenteEcosistema", x => x.ContinenteEcosistemaId);
                    table.ForeignKey(
                        name: "FK_ContinenteEcosistema_Continente_ContinenteId",
                        column: x => x.ContinenteId,
                        principalTable: "Continente",
                        principalColumn: "ContinenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContinenteEcosistema_Ecosistema_EcosistemaId",
                        column: x => x.EcosistemaId,
                        principalTable: "Ecosistema",
                        principalColumn: "EcosistemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContinenteEcosistema_ContinenteId",
                table: "ContinenteEcosistema",
                column: "ContinenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ContinenteEcosistema_EcosistemaId",
                table: "ContinenteEcosistema",
                column: "EcosistemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContinenteEcosistema");
        }
    }
}
