using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDeDatos.Migrations
{
    /// <inheritdoc />
    public partial class cambioKeyCabaña : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mantenimientos_cabañas_CabañaNombre",
                table: "mantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_mantenimientos_CabañaNombre",
                table: "mantenimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cabañas",
                table: "cabañas");

            migrationBuilder.DropColumn(
                name: "CabañaNombre",
                table: "mantenimientos");

            migrationBuilder.AddColumn<int>(
                name: "CabañaNroHabitacion",
                table: "mantenimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "cabañas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "NroHabitacion",
                table: "cabañas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cabañas",
                table: "cabañas",
                column: "NroHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_mantenimientos_CabañaNroHabitacion",
                table: "mantenimientos",
                column: "CabañaNroHabitacion");

            migrationBuilder.AddForeignKey(
                name: "FK_mantenimientos_cabañas_CabañaNroHabitacion",
                table: "mantenimientos",
                column: "CabañaNroHabitacion",
                principalTable: "cabañas",
                principalColumn: "NroHabitacion",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mantenimientos_cabañas_CabañaNroHabitacion",
                table: "mantenimientos");

            migrationBuilder.DropIndex(
                name: "IX_mantenimientos_CabañaNroHabitacion",
                table: "mantenimientos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cabañas",
                table: "cabañas");

            migrationBuilder.DropColumn(
                name: "CabañaNroHabitacion",
                table: "mantenimientos");

            migrationBuilder.DropColumn(
                name: "NroHabitacion",
                table: "cabañas");

            migrationBuilder.AddColumn<string>(
                name: "CabañaNombre",
                table: "mantenimientos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "cabañas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cabañas",
                table: "cabañas",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_mantenimientos_CabañaNombre",
                table: "mantenimientos",
                column: "CabañaNombre");

            migrationBuilder.AddForeignKey(
                name: "FK_mantenimientos_cabañas_CabañaNombre",
                table: "mantenimientos",
                column: "CabañaNombre",
                principalTable: "cabañas",
                principalColumn: "Nombre");
        }
    }
}
