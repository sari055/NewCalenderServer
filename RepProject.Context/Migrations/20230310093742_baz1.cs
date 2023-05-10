using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepProject.Context.Migrations
{
    /// <inheritdoc />
    public partial class baz1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Children",
                newName: "ChildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChildId",
                table: "Children",
                newName: "Id");
        }
    }
}
