using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCountryOfEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
