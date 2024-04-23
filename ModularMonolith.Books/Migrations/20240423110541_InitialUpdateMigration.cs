using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModularMonolith.Books.Migrations
{
    /// <inheritdoc />
    public partial class InitialUpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Books_Title",
                schema: "Books",
                table: "Books",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Name",
                schema: "Books",
                table: "Authors",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_Title",
                schema: "Books",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Authors_Name",
                schema: "Books",
                table: "Authors");
        }
    }
}
