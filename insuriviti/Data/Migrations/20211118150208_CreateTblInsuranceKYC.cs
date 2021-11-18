using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace insuriviti.Data.Migrations
{
    public partial class CreateTblInsuranceKYC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceKYC",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INumber = table.Column<string>(type: "Varchar(10)", nullable: true),
                    EmpName = table.Column<string>(type: "Varchar(100)", nullable: true),
                    EmpDOB = table.Column<DateTime>(type: "Date", nullable: true),
                    CitizenshipNo = table.Column<string>(type: "Varchar(100)", nullable: true),
                    CitizenshipIssueDate = table.Column<DateTime>(type: "Date", nullable: true),
                    FatherName = table.Column<string>(type: "Varchar(100)", nullable: true),
                    FatherDOB = table.Column<DateTime>(type: "Date", nullable: true),
                    MotherName = table.Column<string>(type: "Varchar(100)", nullable: true),
                    MotherDOB = table.Column<DateTime>(type: "Date", nullable: true),
                    PlanOption = table.Column<int>(type: "int", nullable: false),
                    SpouseName = table.Column<string>(type: "Varchar(100)", nullable: true),
                    SpouseDOB = table.Column<DateTime>(type: "Date", nullable: true),
                    ChildNameA = table.Column<string>(type: "Varchar(100)", nullable: true),
                    ChildNameB = table.Column<string>(type: "Varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceKYC", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceKYC");
        }
    }
}
