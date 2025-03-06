using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.InfraStructure.Migrations
{
    /// <inheritdoc />
    public partial class fullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Passengers",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Passengers",
                newName: "Firstname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Passengers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Passengers",
                newName: "FirstName");
        }
    }
}
