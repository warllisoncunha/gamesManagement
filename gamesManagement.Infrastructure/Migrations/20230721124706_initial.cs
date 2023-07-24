using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gamesManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(80)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("FriendId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(80)", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("GameId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TakeDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DevolutionDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Observation = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("BorrowedGameId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BorrowedGame_Friend_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Friend",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BorrowedGame_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedGame_FriendId",
                table: "BorrowedGame",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedGame_GameId",
                table: "BorrowedGame",
                column: "GameId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedGame");

            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
