using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class Add_Data_Into_Table_12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSalary",
                table: "EmployeeSalarys",
                nullable: false,
                computedColumnSql: "[BasicSalary]+[HRA]",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalSalary",
                table: "EmployeeSalarys",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldComputedColumnSql: "[BasicSalary]+[HRA]");
        }
    }
}
