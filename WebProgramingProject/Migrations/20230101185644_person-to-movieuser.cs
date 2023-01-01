using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramingProject.Migrations
{
    /// <inheritdoc />
    public partial class persontomovieuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Person_PersonId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_PersonId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Review",
                newName: "MovieUser");

            migrationBuilder.AddColumn<string>(
                name: "ReviewerId",
                table: "Review",
                type: "nvarchar(450)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_AspNetUsers_ReviewerId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Review_ReviewerId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Review");

            migrationBuilder.RenameColumn(
                name: "MovieUser",
                table: "Review",
                newName: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_PersonId",
                table: "Review",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Person_PersonId",
                table: "Review",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
