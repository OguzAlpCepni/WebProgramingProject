using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramingProject.Migrations
{
    /// <inheritdoc />
    public partial class reviewtypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ReviewerId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "MovieUser",
                table: "Review");

            migrationBuilder.AlterColumn<int>(
                name: "ReviewerId",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewerId1",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewerId1",
                table: "Review",
                column: "ReviewerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId1",
                table: "Review",
                column: "ReviewerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId1",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ReviewerId1",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ReviewerId1",
                table: "Review");

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerId",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MovieUser",
                table: "Review",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewerId",
                table: "Review",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId",
                table: "Review",
                column: "ReviewerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
