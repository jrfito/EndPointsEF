using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPointsEF.Migrations
{
    public partial class AddFieldsToCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoPostal",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "Cliente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroExterior",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "CodigoPostal",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "NumeroExterior",
                table: "Cliente");
        }
    }
}
