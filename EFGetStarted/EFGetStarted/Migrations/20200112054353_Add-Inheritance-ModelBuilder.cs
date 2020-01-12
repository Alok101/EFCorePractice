using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class AddInheritanceModelBuilder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Blog_Ins");

            migrationBuilder.AddColumn<string>(
                name: "blog_type",
                table: "Blog_Ins",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "blog_type",
                table: "Blog_Ins");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Blog_Ins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
