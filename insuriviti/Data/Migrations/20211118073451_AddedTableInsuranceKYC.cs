using Microsoft.EntityFrameworkCore.Migrations;

namespace insuriviti.Data.Migrations
{
    public partial class AddedTableInsuranceKYC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceKYC",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    INumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenshipNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CitizenshipIssueDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FatherDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotherDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseDOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildNameA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildNameB = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
