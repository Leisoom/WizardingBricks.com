using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizardingBricks.Migrations
{
    /// <inheritdoc />
    public partial class MakeCategoriesPropertyInSetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Categories_CategoryId",
                table: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Sets_CategoryId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sets");

            migrationBuilder.CreateTable(
                name: "CategorySet",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    SetsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySet", x => new { x.CategoriesId, x.SetsId });
                    table.ForeignKey(
                        name: "FK_CategorySet_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySet_Sets_SetsId",
                        column: x => x.SetsId,
                        principalTable: "Sets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorySet_SetsId",
                table: "CategorySet",
                column: "SetsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategorySet");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Sets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sets_CategoryId",
                table: "Sets",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sets_Categories_CategoryId",
                table: "Sets",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
