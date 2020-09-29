using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPointsEF.Migrations
{
    public partial class apiFluentTipoMuebleIndiceDescripcion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TipoMueble_Descripcion",
                table: "TipoMueble",
                column: "Descripcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TipoMueble_Descripcion",
                table: "TipoMueble");
        }
    }
}
