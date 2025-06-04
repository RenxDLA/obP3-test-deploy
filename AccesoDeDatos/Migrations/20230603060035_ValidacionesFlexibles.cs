using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDeDatos.Migrations
{
    /// <inheritdoc />
    public partial class ValidacionesFlexibles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "configuraciones",
                columns: table => new
                {
                    Atributo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LimiteSuperior = table.Column<int>(type: "int", nullable: false),
                    LimiteInferior = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuraciones", x => x.Atributo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuraciones");
        }
    }
}
