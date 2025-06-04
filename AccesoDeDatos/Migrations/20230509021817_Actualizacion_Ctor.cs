using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDeDatos.Migrations
{
    /// <inheritdoc />
    public partial class Actualizacion_Ctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "funcionarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "funcionarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
