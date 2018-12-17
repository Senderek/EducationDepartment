using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationDepartment.Infrastructure.Entityframework.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTypeFieldTypes",
                table: "ArticleTypeFieldTypes");

            migrationBuilder.DropIndex(
                name: "IX_ArticleTypeFieldTypes_ArticleTypeId",
                table: "ArticleTypeFieldTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ArticleTypeFieldTypes");

            migrationBuilder.DropColumn(
                name: "DefaultPriority",
                table: "ArticleTypeFieldTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTypeFieldTypes",
                table: "ArticleTypeFieldTypes",
                columns: new[] { "ArticleTypeId", "FieldTypeId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ArticleTypeFieldTypes",
                table: "ArticleTypeFieldTypes");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ArticleTypeFieldTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DefaultPriority",
                table: "ArticleTypeFieldTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArticleTypeFieldTypes",
                table: "ArticleTypeFieldTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTypeFieldTypes_ArticleTypeId",
                table: "ArticleTypeFieldTypes",
                column: "ArticleTypeId");
        }
    }
}
