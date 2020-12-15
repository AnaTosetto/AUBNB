using Microsoft.EntityFrameworkCore.Migrations;

namespace AUBNB.Infra.Data.Migrations
{
    public partial class AlterTypeColumnNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Note",
                schema: "dbo",
                table: "Hostings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Note",
                schema: "dbo",
                table: "Hostings",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
