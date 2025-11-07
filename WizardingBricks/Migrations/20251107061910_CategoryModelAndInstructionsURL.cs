using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizardingBricks.Migrations
{
    /// <inheritdoc />
    public partial class CategoryModelAndInstructionsURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preview_URL",
                table: "Sets",
                newName: "Preview_Image_URL");

            migrationBuilder.AddColumn<string>(
                name: "Instructions_URL",
                table: "Sets",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Instructions_URL",
                table: "Sets");

            migrationBuilder.RenameColumn(
                name: "Preview_Image_URL",
                table: "Sets",
                newName: "Preview_URL");
        }
    }
}
