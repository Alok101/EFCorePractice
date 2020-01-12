using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class Manual_Configuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog_Rs",
                columns: table => new
                {
                    Blog_RSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog_Rs", x => x.Blog_RSId);
                });

            migrationBuilder.CreateTable(
                name: "Post_Rs",
                columns: table => new
                {
                    Post_RSId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Blog_RSId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Rs", x => x.Post_RSId);
                    table.ForeignKey(
                        name: "FK_Post_Rs_Blog_Rs_Blog_RSId",
                        column: x => x.Blog_RSId,
                        principalTable: "Blog_Rs",
                        principalColumn: "Blog_RSId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_Rs_Blog_RSId",
                table: "Post_Rs",
                column: "Blog_RSId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_Rs");

            migrationBuilder.DropTable(
                name: "Blog_Rs");
        }
    }
}
