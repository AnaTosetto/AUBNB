using Microsoft.EntityFrameworkCore.Migrations;

namespace AUBNB.Infra.Data.Migrations
{
    public partial class AddColumnsTableHosting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Hostings",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "AnimalSize",
                schema: "dbo",
                table: "Hostings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HasDog",
                schema: "dbo",
                table: "Hostings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HousingType",
                schema: "dbo",
                table: "Hostings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatioSize",
                schema: "dbo",
                table: "Hostings",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlaceDescription",
                schema: "dbo",
                table: "Hostings",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnimalSize",
                schema: "dbo",
                table: "Hostings");

            migrationBuilder.DropColumn(
                name: "HasDog",
                schema: "dbo",
                table: "Hostings");

            migrationBuilder.DropColumn(
                name: "HousingType",
                schema: "dbo",
                table: "Hostings");

            migrationBuilder.DropColumn(
                name: "PatioSize",
                schema: "dbo",
                table: "Hostings");

            migrationBuilder.DropColumn(
                name: "PlaceDescription",
                schema: "dbo",
                table: "Hostings");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "dbo",
                table: "Hostings",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
