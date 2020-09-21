using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPointsEF.Migrations
{
    public partial class FixIIAddClienteFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Cliente_ClienteEntityId",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ClienteEntityId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ClienteEntityId",
                table: "Factura");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Factura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Cliente_ClienteId",
                table: "Factura",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Cliente_ClienteId",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_ClienteId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Factura");

            migrationBuilder.AddColumn<int>(
                name: "ClienteEntityId",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ClienteEntityId",
                table: "Factura",
                column: "ClienteEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Cliente_ClienteEntityId",
                table: "Factura",
                column: "ClienteEntityId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
