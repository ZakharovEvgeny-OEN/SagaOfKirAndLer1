using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SagaOfKirAndLer.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "PlayerGame");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundPath",
                table: "SceneGame",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "SceneGame",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerGame",
                table: "PlayerGame",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerGame",
                table: "PlayerGame");

            migrationBuilder.DropColumn(
                name: "BackgroundPath",
                table: "SceneGame");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "SceneGame");

            migrationBuilder.RenameTable(
                name: "PlayerGame",
                newName: "Player");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");
        }
    }
}
