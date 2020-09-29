using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPointsEF.Migrations
{
    public partial class apiFluentTipoMueble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Customer_ClienteId",
                table: "Factura");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TipoMueble",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMueble", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TipoMueble",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 1, "Linea Blanca" });

            migrationBuilder.InsertData(
                table: "TipoMueble",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 2, "Electrodomesticos" });

            migrationBuilder.InsertData(
                table: "TipoMueble",
                columns: new[] { "Id", "Descripcion" },
                values: new object[] { 3, "Electrónica" });

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

            migrationBuilder.DropTable(
                name: "TipoMueble");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Customer_ClienteId",
                table: "Factura",
                column: "ClienteId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
