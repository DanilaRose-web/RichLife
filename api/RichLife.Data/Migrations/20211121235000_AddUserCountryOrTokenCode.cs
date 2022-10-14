using Microsoft.EntityFrameworkCore.Migrations;

namespace RichLife.Data.Migrations
{
    public partial class AddUserCountryOrTokenCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "UserTokens",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodeNumber",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "CodeNumber",
                table: "Users");
        }
    }
}
