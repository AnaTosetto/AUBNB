using Microsoft.EntityFrameworkCore.Migrations;

namespace AUBNB.Infra.Data.Migrations
{
    public partial class AddCryptUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                schema: "dbo",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                schema: "dbo",
                table: "Users");
        }
    }
}
