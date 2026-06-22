using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ispublished",
                table: "Articles",
                newName: "IsPublished");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsPublished",
                table: "Articles",
                newName: "Ispublished");
        }
    }
}
