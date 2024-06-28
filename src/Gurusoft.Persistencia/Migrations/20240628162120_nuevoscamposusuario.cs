using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gurusoft.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class nuevoscamposusuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellidos",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombres",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellidos",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Nombres",
                table: "Usuario");
        }
    }
}
