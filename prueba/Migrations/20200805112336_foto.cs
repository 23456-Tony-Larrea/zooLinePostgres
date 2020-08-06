using Microsoft.EntityFrameworkCore.Migrations;

namespace prueba.Migrations
{
    public partial class foto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Usuario",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "fotografiaPerfil",
                table: "Usuario",
                newName: "FotografiaPerfil");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "contraseña",
                table: "Usuario",
                newName: "Contraseña");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Usuario",
                newName: "telefono");

            migrationBuilder.RenameColumn(
                name: "FotografiaPerfil",
                table: "Usuario",
                newName: "fotografiaPerfil");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuario",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "Usuario",
                newName: "contraseña");
        }
    }
}
