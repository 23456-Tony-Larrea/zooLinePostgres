using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooLine.Migrations
{
    public partial class fotoFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotografiaBase64",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "fotoAnimal",
                table: "Animales");

            migrationBuilder.AddColumn<string>(
                name: "NombreImagen",
                table: "Animales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Animales",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreImagen",
                table: "Animales");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Animales");

            migrationBuilder.AddColumn<string>(
                name: "FotografiaBase64",
                table: "Animales",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "fotoAnimal",
                table: "Animales",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[] {  });
        }
    }
}
