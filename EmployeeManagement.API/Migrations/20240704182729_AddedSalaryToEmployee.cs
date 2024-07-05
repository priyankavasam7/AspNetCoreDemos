using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class AddedSalaryToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Salary",
                table: "employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "employees");
        }
    }
}
