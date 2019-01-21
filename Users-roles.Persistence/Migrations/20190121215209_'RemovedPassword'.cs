using Microsoft.EntityFrameworkCore.Migrations;

namespace Users_roles.Persistence.Migrations
{
    public partial class RemovedPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }
    }
}
