using Microsoft.EntityFrameworkCore.Migrations;

namespace AUBNB.Infra.Data.Migrations
{
    public partial class AddHostingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TelephoneNumber",
                schema: "dbo",
                table: "Users",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Users",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Hostings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(maxLength: 250, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Availability = table.Column<bool>(nullable: false),
                    Street = table.Column<string>(maxLength: 250, nullable: false),
                    Number = table.Column<string>(maxLength: 20, nullable: false),
                    Neighborhood = table.Column<string>(maxLength: 250, nullable: false),
                    City = table.Column<string>(maxLength: 250, nullable: false),
                    State = table.Column<string>(maxLength: 250, nullable: false),
                    Country = table.Column<string>(maxLength: 250, nullable: false),
                    PostalCode = table.Column<string>(maxLength: 50, nullable: false),
                    AdditionalInfo = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hostings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hostings_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hostings_UserId",
                schema: "dbo",
                table: "Hostings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hostings",
                schema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "TelephoneNumber",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
