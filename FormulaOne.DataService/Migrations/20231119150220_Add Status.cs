using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class AddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Drivers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Type1",
                table: "Achievements",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Achievements",
                newName: "RaceWins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Drivers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Achievements",
                newName: "Type1");

            migrationBuilder.RenameColumn(
                name: "RaceWins",
                table: "Achievements",
                newName: "Type");
        }
    }
}
