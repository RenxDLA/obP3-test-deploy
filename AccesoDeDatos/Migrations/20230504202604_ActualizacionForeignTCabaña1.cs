using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDeDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionForeignTCabaña1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cabañas_tipos_TipoNombre",
                table: "cabañas");

            migrationBuilder.DropIndex(
                name: "IX_cabañas_TipoNombre",
                table: "cabañas");

            migrationBuilder.DropColumn(
                name: "TipoNombre",
                table: "cabañas");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cabañas_tipos_Nombre",
                table: "cabañas");

            migrationBuilder.DropIndex(
                name: "IX_cabañas_Nombre",
                table: "cabañas");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "cabañas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "TipoNombre",
                table: "cabañas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_cabañas_TipoNombre",
                table: "cabañas",
                column: "TipoNombre");

            migrationBuilder.AddForeignKey(
                name: "FK_cabañas_tipos_TipoNombre",
                table: "cabañas",
                column: "TipoNombre",
                principalTable: "tipos",
                principalColumn: "Nombre",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
