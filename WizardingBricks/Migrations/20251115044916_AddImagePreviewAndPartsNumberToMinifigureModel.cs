using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizardingBricks.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePreviewAndPartsNumberToMinifigureModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number_Of_Parts",
                table: "Minifigures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Preview_Image_URL",
                table: "Minifigures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number_Of_Parts",
                table: "Minifigures");

            migrationBuilder.DropColumn(
                name: "Preview_Image_URL",
                table: "Minifigures");
        }
    }
}
