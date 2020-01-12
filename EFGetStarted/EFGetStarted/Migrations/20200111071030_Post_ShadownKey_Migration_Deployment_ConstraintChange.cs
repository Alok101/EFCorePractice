using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class Post_ShadownKey_Migration_Deployment_ConstraintChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_FK_Blog_FK_BloogerForeignKeyId",
                table: "Post_FK");

            migrationBuilder.AddForeignKey(
                name: "Foreign_Key_Constraint_Category",
                table: "Post_FK",
                column: "BloogerForeignKeyId",
                principalTable: "Blog_FK",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Foreign_Key_Constraint_Category",
                table: "Post_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_FK_Blog_FK_BloogerForeignKeyId",
                table: "Post_FK",
                column: "BloogerForeignKeyId",
                principalTable: "Blog_FK",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
