using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDeDatos.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionForeignMantenimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mantenimientos_cabañas_CabañaNroHabitacion",
                table: "mantenimientos");

            migrationBuilder.RenameColumn(
                name: "CabañaNroHabitacion",
                table: "mantenimientos",
                newName: "NroHabitacion");

            migrationBuilder.RenameIndex(
                name: "IX_mantenimientos_CabañaNroHabitacion",
                table: "mantenimientos",
                newName: "IX_mantenimientos_NroHabitacion");

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
                column: "Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_mantenimientos_cabañas_NroHabitacion",
                table: "mantenimientos",
                column: "NroHabitacion",
                principalTable: "cabañas",
                principalColumn: "NroHabitacion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mantenimientos_cabañas_NroHabitacion",
                table: "mantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_cabañas_Nombre",
                table: "cabañas");

            migrationBuilder.RenameColumn(
                name: "NroHabitacion",
                table: "mantenimientos",
                newName: "CabañaNroHabitacion");

            migrationBuilder.RenameIndex(
                name: "IX_mantenimientos_NroHabitacion",
                table: "mantenimientos",
                newName: "IX_mantenimientos_CabañaNroHabitacion");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "cabañas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_mantenimientos_cabañas_CabañaNroHabitacion",
                table: "mantenimientos",
                column: "CabañaNroHabitacion",
                principalTable: "cabañas",
                principalColumn: "NroHabitacion",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
