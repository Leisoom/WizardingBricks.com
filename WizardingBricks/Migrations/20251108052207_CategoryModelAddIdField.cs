using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizardingBricks.Migrations
{
    /// <inheritdoc />
    public partial class CategoryModelAddIdField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Sets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sets_Categories_CategoryId",
                table: "Sets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Sets_CategoryId",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sets");
        }
    }
}
