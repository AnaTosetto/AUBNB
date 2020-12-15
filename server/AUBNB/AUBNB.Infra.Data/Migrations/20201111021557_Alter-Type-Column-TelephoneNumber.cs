using Microsoft.EntityFrameworkCore.Migrations;

namespace AUBNB.Infra.Data.Migrations
{
    public partial class AlterTypeColumnTelephoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TelephoneNumber",
                schema: "dbo",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TelephoneNumber",
                schema: "dbo",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
