using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameReviewSolution.Migrations
{
    public partial class updatemodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewPosts_Games_GameId",
                table: "ReviewPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewPosts_Users_UserId",
                table: "ReviewPosts");

            migrationBuilder.DropIndex(
                name: "IX_ReviewPosts_UserId",
                table: "ReviewPosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ReviewPosts");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "ReviewPosts",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "ReviewPosts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPosts_AuthorId",
                table: "ReviewPosts",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewPosts_Games_GameId",
                table: "ReviewPosts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewPosts_Users_AuthorId",
                table: "ReviewPosts",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewPosts_Games_GameId",
                table: "ReviewPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReviewPosts_Users_AuthorId",
                table: "ReviewPosts");

            migrationBuilder.DropIndex(
                name: "IX_ReviewPosts_AuthorId",
                table: "ReviewPosts");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "ReviewPosts");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "ReviewPosts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ReviewPosts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReviewPosts_UserId",
                table: "ReviewPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewPosts_Games_GameId",
                table: "ReviewPosts",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewPosts_Users_UserId",
                table: "ReviewPosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
