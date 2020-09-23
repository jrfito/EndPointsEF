using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPointsEF.Migrations
{
    public partial class EntityExample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnotationExample",
                columns: table => new
                {
                    IdKey = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StringCharTen = table.Column<string>(maxLength: 10, nullable: true),
                    StringVarCharTen = table.Column<string>(type: "VarChar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnotationExample", x => x.IdKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnotationExample");
        }
    }
}
