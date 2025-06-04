using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDeDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionForeignTipo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cabañas_tipos_Nombre",
                table: "cabañas");

            migrationBuilder.DropIndex(
                name: "IX_cabañas_Nombre",
                table: "cabañas");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "tipos",
                newName: "NombreTipo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "cabañas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "NombreTipo",
                table: "cabañas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_cabañas_NombreTipo",
                table: "cabañas",
                column: "NombreTipo");

            migrationBuilder.AddForeignKey(
                name: "FK_cabañas_tipos_NombreTipo",
                table: "cabañas",
                column: "NombreTipo",
                principalTable: "tipos",
                principalColumn: "NombreTipo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cabañas_tipos_NombreTipo",
                table: "cabañas");

            migrationBuilder.DropIndex(
                name: "IX_cabañas_NombreTipo",
                table: "cabañas");

            migrationBuilder.DropColumn(
                name: "NombreTipo",
                table: "cabañas");

            migrationBuilder.RenameColumn(
                name: "NombreTipo",
                table: "tipos",
                newName: "Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "cabañas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_cabañas_Nombre",
                table: "cabañas",
                column: "Nombre");

            migrationBuilder.AddForeignKey(
                name: "FK_cabañas_tipos_Nombre",
                table: "cabañas",
                column: "Nombre",
                principalTable: "tipos",
                principalColumn: "Nombre",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
