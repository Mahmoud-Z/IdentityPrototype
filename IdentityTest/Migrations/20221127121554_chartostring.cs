using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityTest.Migrations
{
    public partial class chartostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "testChar",
                table: "Documents",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "testChar",
                table: "Documents");
        }
    }
}
