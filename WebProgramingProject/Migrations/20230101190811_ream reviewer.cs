using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramingProject.Migrations
{
    /// <inheritdoc />
    public partial class reamreviewer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId1",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "ReviewerId1",
                table: "Review",
                newName: "MovieUserId1");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Review",
                newName: "MovieUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_ReviewerId1",
                table: "Review",
                newName: "IX_Review_MovieUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_MovieUserId1",
                table: "Review",
                column: "MovieUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_MovieUserId1",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "MovieUserId1",
                table: "Review",
                newName: "ReviewerId1");

            migrationBuilder.RenameColumn(
                name: "MovieUserId",
                table: "Review",
                newName: "ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_Review_MovieUserId1",
                table: "Review",
                newName: "IX_Review_ReviewerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId1",
                table: "Review",
                column: "ReviewerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
