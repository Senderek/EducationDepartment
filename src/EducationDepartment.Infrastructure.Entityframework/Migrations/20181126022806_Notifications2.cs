using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationDepartment.Infrastructure.Entityframework.Migrations
{
    public partial class Notifications2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DestinationsAsString",
                table: "Notifications",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationsAsString",
                table: "Notifications");
        }
    }
}
