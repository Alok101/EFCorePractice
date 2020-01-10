using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class Add_Data_Into_Table_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "EmployeeSalarys",
               columns: table => new
               {
                   EmpId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   BasicSalary = table.Column<decimal>(nullable: false),
                   HRA = table.Column<decimal>(nullable: false),
                   TotalSalary = table.Column<decimal>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_EmployeeSalarys", x => x.EmpId);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.DropTable(
                name: "EmployeeSalarys");

        }
    }
}
