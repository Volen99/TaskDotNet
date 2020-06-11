using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskDotNet.Data.Migrations
{
    public partial class ManyToManyTableNameFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOffices_Employees_EmployeeId",
                table: "EmployeeOffices");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOffices_Offices_OfficeId",
                table: "EmployeeOffices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeOffices",
                table: "EmployeeOffices");

            migrationBuilder.RenameTable(
                name: "EmployeeOffices",
                newName: "EmployeesOffices");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeOffices_OfficeId",
                table: "EmployeesOffices",
                newName: "IX_EmployeesOffices_OfficeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesOffices",
                table: "EmployeesOffices",
                columns: new[] { "EmployeeId", "OfficeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesOffices_Employees_EmployeeId",
                table: "EmployeesOffices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeesOffices_Offices_OfficeId",
                table: "EmployeesOffices",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesOffices_Employees_EmployeeId",
                table: "EmployeesOffices");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeesOffices_Offices_OfficeId",
                table: "EmployeesOffices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesOffices",
                table: "EmployeesOffices");

            migrationBuilder.RenameTable(
                name: "EmployeesOffices",
                newName: "EmployeeOffices");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeesOffices_OfficeId",
                table: "EmployeeOffices",
                newName: "IX_EmployeeOffices_OfficeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeOffices",
                table: "EmployeeOffices",
                columns: new[] { "EmployeeId", "OfficeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOffices_Employees_EmployeeId",
                table: "EmployeeOffices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOffices_Offices_OfficeId",
                table: "EmployeeOffices",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
