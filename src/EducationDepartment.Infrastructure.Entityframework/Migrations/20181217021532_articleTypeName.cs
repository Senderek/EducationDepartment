using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationDepartment.Infrastructure.Entityframework.Migrations
{
    public partial class articleTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArticleTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArticleTypes");
        }
    }
}
