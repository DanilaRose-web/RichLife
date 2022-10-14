using Microsoft.EntityFrameworkCore.Migrations;

namespace RichLife.Data.Migrations
{
    public partial class correctUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefferalKey",
                table: "Users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefferalKey",
                table: "Users");
        }
    }
}
