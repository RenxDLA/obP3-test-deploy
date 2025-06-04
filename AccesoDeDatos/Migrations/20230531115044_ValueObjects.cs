using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDeDatos.Migrations
{
    /// <inheritdoc />
    public partial class ValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "costoPorHuesped_Valor",
                table: "tipos",
                newName: "costoPorHuesped");

            migrationBuilder.RenameColumn(
                name: "Descripcion_Valor",
                table: "tipos",
                newName: "Descripcion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "costoPorHuesped",
                table: "tipos",
                newName: "costoPorHuesped_Valor");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "tipos",
                newName: "Descripcion_Valor");
        }
    }
}
