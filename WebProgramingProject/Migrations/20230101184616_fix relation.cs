using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramingProject.Migrations
{
    /// <inheritdoc />
    public partial class fixrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategory_Category_CategoryId",
                table: "MovieCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategory_Movie_MovieId",
                table: "MovieCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviePerson_Movie_MovieId",
                table: "MoviePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviePerson_Person_PersonId",
                table: "MoviePerson");

            migrationBuilder.DropTable(
                name: "CategoryMovie");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "MoviePerson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MoviePerson",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieCategory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "MovieCategory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_CategoryId",
                table: "Movie",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Category_CategoryId",
                table: "Movie",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategory_Category_CategoryId",
                table: "MovieCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategory_Movie_MovieId",
                table: "MovieCategory",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePerson_Movie_MovieId",
                table: "MoviePerson",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePerson_Person_PersonId",
                table: "MoviePerson",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Category_CategoryId",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategory_Category_CategoryId",
                table: "MovieCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCategory_Movie_MovieId",
                table: "MovieCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviePerson_Movie_MovieId",
                table: "MoviePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_MoviePerson_Person_PersonId",
                table: "MoviePerson");

            migrationBuilder.DropIndex(
                name: "IX_Movie_CategoryId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Movie");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "MoviePerson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MoviePerson",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MovieCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "MovieCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "CategoryMovie",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMovie", x => new { x.CategoriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMovie_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMovie_MoviesId",
                table: "CategoryMovie",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategory_Category_CategoryId",
                table: "MovieCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCategory_Movie_MovieId",
                table: "MovieCategory",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePerson_Movie_MovieId",
                table: "MoviePerson",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePerson_Person_PersonId",
                table: "MoviePerson",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");
        }
    }
}
