using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace insuriviti.Data.Migrations
{
    public partial class CreatedClaimSubmitTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClaimSubmit",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelationWithPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupPolicyNo = table.Column<int>(type: "int", nullable: false),
                    NatureOfSick = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverageEffDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfTreatementPaperAttached = table.Column<int>(type: "int", nullable: false),
                    NoOfBillAttached = table.Column<int>(type: "int", nullable: false),
                    TotalAmountClaimed = table.Column<float>(type: "real", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeOfAccident = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompelledDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnToWorkDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeRepresentativeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimSubmit", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClaimSubmit");
        }
    }
}
