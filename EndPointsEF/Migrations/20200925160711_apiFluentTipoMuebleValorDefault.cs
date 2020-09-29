using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPointsEF.Migrations
{
    public partial class apiFluentTipoMuebleValorDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroRegistro",
                table: "TipoMueble",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Mueble",
                nullable: false,
                defaultValue: "XX",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroRegistro",
                table: "TipoMueble");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Mueble",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldDefaultValue: "XX");
        }
    }
}
