using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPointsEF.Migrations
{
    public partial class FixIIIAddClienteFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Factura_FacturaEntityId",
                table: "DetalleFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Mueble_MuebleEntityId",
                table: "DetalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFactura_FacturaEntityId",
                table: "DetalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFactura_MuebleEntityId",
                table: "DetalleFactura");

            migrationBuilder.DropColumn(
                name: "FacturaEntityId",
                table: "DetalleFactura");

            migrationBuilder.DropColumn(
                name: "MuebleEntityId",
                table: "DetalleFactura");

            migrationBuilder.AddColumn<int>(
                name: "FacturaId",
                table: "DetalleFactura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuebleId",
                table: "DetalleFactura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_FacturaId",
                table: "DetalleFactura",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_MuebleId",
                table: "DetalleFactura",
                column: "MuebleId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Factura_FacturaId",
                table: "DetalleFactura",
                column: "FacturaId",
                principalTable: "Factura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Mueble_MuebleId",
                table: "DetalleFactura",
                column: "MuebleId",
                principalTable: "Mueble",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Factura_FacturaId",
                table: "DetalleFactura");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFactura_Mueble_MuebleId",
                table: "DetalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFactura_FacturaId",
                table: "DetalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_DetalleFactura_MuebleId",
                table: "DetalleFactura");

            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "DetalleFactura");

            migrationBuilder.DropColumn(
                name: "MuebleId",
                table: "DetalleFactura");

            migrationBuilder.AddColumn<int>(
                name: "FacturaEntityId",
                table: "DetalleFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuebleEntityId",
                table: "DetalleFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_FacturaEntityId",
                table: "DetalleFactura",
                column: "FacturaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFactura_MuebleEntityId",
                table: "DetalleFactura",
                column: "MuebleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Factura_FacturaEntityId",
                table: "DetalleFactura",
                column: "FacturaEntityId",
                principalTable: "Factura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFactura_Mueble_MuebleEntityId",
                table: "DetalleFactura",
                column: "MuebleEntityId",
                principalTable: "Mueble",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
