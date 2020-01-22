using Microsoft.EntityFrameworkCore.Migrations;

namespace ScaffoldMigrationApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestColumn",
                table: "Countries");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestColumn",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
