using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class Post_ShadownKey_Migration_Deployment_ConstraintChange_WithOut_Navigation_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog_FK_AK",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog_FK_AK", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Post_FK_AK",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_FK_AK", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_AK_ForeignKey_Contraint",
                        column: x => x.BlogId,
                        principalTable: "Blog_FK_AK",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_FK_AK_BlogId",
                table: "Post_FK_AK",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_FK_AK");

            migrationBuilder.DropTable(
                name: "Blog_FK_AK");
        }
    }
}
