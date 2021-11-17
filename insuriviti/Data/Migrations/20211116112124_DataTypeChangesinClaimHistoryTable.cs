using Microsoft.EntityFrameworkCore.Migrations;

namespace insuriviti.Data.Migrations
{
    public partial class DataTypeChangesinClaimHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimHistory_ClaimStatus_ClaimStatusId",
                table: "ClaimHistory");

            migrationBuilder.DropColumn(
                name: "LastUpdateUserId",
                table: "ClaimHistory");

            migrationBuilder.RenameColumn(
                name: "ClaimStatusId",
                table: "ClaimHistory",
                newName: "ClaimStatusID");

            migrationBuilder.RenameColumn(
                name: "StatusID",
                table: "ClaimHistory",
                newName: "LastUpdateUser");

            migrationBuilder.RenameIndex(
                name: "IX_ClaimHistory_ClaimStatusId",
                table: "ClaimHistory",
                newName: "IX_ClaimHistory_ClaimStatusID");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimStatusID",
                table: "ClaimHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimHistory_ClaimStatus_ClaimStatusID",
                table: "ClaimHistory",
                column: "ClaimStatusID",
                principalTable: "ClaimStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClaimHistory_ClaimStatus_ClaimStatusID",
                table: "ClaimHistory");

            migrationBuilder.RenameColumn(
                name: "ClaimStatusID",
                table: "ClaimHistory",
                newName: "ClaimStatusId");

            migrationBuilder.RenameColumn(
                name: "LastUpdateUser",
                table: "ClaimHistory",
                newName: "StatusID");

            migrationBuilder.RenameIndex(
                name: "IX_ClaimHistory_ClaimStatusID",
                table: "ClaimHistory",
                newName: "IX_ClaimHistory_ClaimStatusId");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimStatusId",
                table: "ClaimHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LastUpdateUserId",
                table: "ClaimHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ClaimHistory_ClaimStatus_ClaimStatusId",
                table: "ClaimHistory",
                column: "ClaimStatusId",
                principalTable: "ClaimStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
