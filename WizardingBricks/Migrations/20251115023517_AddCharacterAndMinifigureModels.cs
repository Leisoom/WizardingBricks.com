using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizardingBricks.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterAndMinifigureModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Minifigures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minifigures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minifigures_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinifigureSet",
                columns: table => new
                {
                    MinifiguresId = table.Column<int>(type: "int", nullable: false),
                    SetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinifigureSet", x => new { x.MinifiguresId, x.SetsId });
                    table.ForeignKey(
                        name: "FK_MinifigureSet_Minifigures_MinifiguresId",
                        column: x => x.MinifiguresId,
                        principalTable: "Minifigures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MinifigureSet_Sets_SetsId",
                        column: x => x.SetsId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CharacterId",
                table: "Categories",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Minifigures_CharacterId",
                table: "Minifigures",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_MinifigureSet_SetsId",
                table: "MinifigureSet",
                column: "SetsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Characters_CharacterId",
                table: "Categories",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Characters_CharacterId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "MinifigureSet");

            migrationBuilder.DropTable(
                name: "Minifigures");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CharacterId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Categories");
        }
    }
}
