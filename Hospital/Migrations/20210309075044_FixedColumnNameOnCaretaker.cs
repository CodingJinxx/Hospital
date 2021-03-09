using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class FixedColumnNameOnCaretaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARE_TAKERS_CARE_TAKERS_SupervisorId",
                table: "CARE_TAKERS");

            migrationBuilder.RenameColumn(
                name: "SupervisorId",
                table: "CARE_TAKERS",
                newName: "SUPERVISOR_ID");

            migrationBuilder.RenameIndex(
                name: "IX_CARE_TAKERS_SupervisorId",
                table: "CARE_TAKERS",
                newName: "IX_CARE_TAKERS_SUPERVISOR_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CARE_TAKERS_CARE_TAKERS_SUPERVISOR_ID",
                table: "CARE_TAKERS",
                column: "SUPERVISOR_ID",
                principalTable: "CARE_TAKERS",
                principalColumn: "EMPLOYEE_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARE_TAKERS_CARE_TAKERS_SUPERVISOR_ID",
                table: "CARE_TAKERS");

            migrationBuilder.RenameColumn(
                name: "SUPERVISOR_ID",
                table: "CARE_TAKERS",
                newName: "SupervisorId");

            migrationBuilder.RenameIndex(
                name: "IX_CARE_TAKERS_SUPERVISOR_ID",
                table: "CARE_TAKERS",
                newName: "IX_CARE_TAKERS_SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CARE_TAKERS_CARE_TAKERS_SupervisorId",
                table: "CARE_TAKERS",
                column: "SupervisorId",
                principalTable: "CARE_TAKERS",
                principalColumn: "EMPLOYEE_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
