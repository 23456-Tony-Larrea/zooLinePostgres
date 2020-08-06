using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace prueba.Migrations
{
    public partial class fkAnimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EspecieId",
                table: "Animales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VegetacionAnimal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VegetacionId = table.Column<int>(nullable: false),
                    AnimalId = table.Column<int>(nullable: false),
                    AnimalesAnimalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VegetacionAnimal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VegetacionAnimal_Animales_AnimalesAnimalId",
                        column: x => x.AnimalesAnimalId,
                        principalTable: "Animales",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VegetacionAnimal_Vegetacion_VegetacionId",
                        column: x => x.VegetacionId,
                        principalTable: "Vegetacion",
                        principalColumn: "VegetacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animales_EspecieId",
                table: "Animales",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_VegetacionAnimal_AnimalesAnimalId",
                table: "VegetacionAnimal",
                column: "AnimalesAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_VegetacionAnimal_VegetacionId",
                table: "VegetacionAnimal",
                column: "VegetacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animales_Especie_EspecieId",
                table: "Animales",
                column: "EspecieId",
                principalTable: "Especie",
                principalColumn: "EspecieId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animales_Especie_EspecieId",
                table: "Animales");

            migrationBuilder.DropTable(
                name: "VegetacionAnimal");

            migrationBuilder.DropIndex(
                name: "IX_Animales_EspecieId",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "EspecieId",
                table: "Animales");
        }
    }
}
