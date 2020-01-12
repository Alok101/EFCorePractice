using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class Add_Shadow_Property_Id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog_FK_AK_PK",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog_FK_AK_PK", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Post_FK_AK_PK",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ShadowBlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_FK_AK_PK", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_FK_AK_PK_Blog_FK_AK_PK_ShadowBlogId",
                        column: x => x.ShadowBlogId,
                        principalTable: "Blog_FK_AK_PK",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_FK_AK_PK_ShadowBlogId",
                table: "Post_FK_AK_PK",
                column: "ShadowBlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_FK_AK_PK");

            migrationBuilder.DropTable(
                name: "Blog_FK_AK_PK");
        }
    }
}
