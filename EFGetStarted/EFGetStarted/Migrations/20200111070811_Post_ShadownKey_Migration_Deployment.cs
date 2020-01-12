using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class Post_ShadownKey_Migration_Deployment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog_FK",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog_FK", x => x.BlogId);
                });

            migrationBuilder.CreateTable(
                name: "Post_FK",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    BloogerForeignKeyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_FK", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_FK_Blog_FK_BloogerForeignKeyId",
                        column: x => x.BloogerForeignKeyId,
                        principalTable: "Blog_FK",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Post_FK_BloogerForeignKeyId",
                table: "Post_FK",
                column: "BloogerForeignKeyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Post_FK");

            migrationBuilder.DropTable(
                name: "Blog_FK");
        }
    }
}
