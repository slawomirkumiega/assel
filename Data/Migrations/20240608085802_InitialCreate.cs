using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assel.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "assel");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "assel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facts",
                schema: "assel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FactText = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PetType = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facts_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "assel",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facts_UserId",
                schema: "assel",
                table: "Facts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facts",
                schema: "assel");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "assel");
        }
    }
}
