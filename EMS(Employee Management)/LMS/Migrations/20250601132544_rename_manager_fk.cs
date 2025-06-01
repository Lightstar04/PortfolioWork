using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class rename_manager_fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Manager",
                table: "Employees",
                newName: "ManagerNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerNumber",
                table: "Employees",
                column: "ManagerNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerNumber",
                table: "Employees",
                column: "ManagerNumber",
                principalTable: "Employees",
                principalColumn: "Number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ManagerNumber",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ManagerNumber",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "ManagerNumber",
                table: "Employees",
                newName: "Manager");
        }
    }
}
