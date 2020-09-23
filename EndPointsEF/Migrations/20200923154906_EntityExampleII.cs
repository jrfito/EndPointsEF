using Microsoft.EntityFrameworkCore.Migrations;

namespace EndPointsEF.Migrations
{
    public partial class EntityExampleII : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StringCharTen",
                table: "AnotationExample");

            migrationBuilder.AddColumn<string>(
                name: "StringNVarCharMax",
                table: "AnotationExample",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringNVarCharTen",
                table: "AnotationExample",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StringText",
                table: "AnotationExample",
                type: "Text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StringNVarCharMax",
                table: "AnotationExample");

            migrationBuilder.DropColumn(
                name: "StringNVarCharTen",
                table: "AnotationExample");

            migrationBuilder.DropColumn(
                name: "StringText",
                table: "AnotationExample");

            migrationBuilder.AddColumn<string>(
                name: "StringCharTen",
                table: "AnotationExample",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
