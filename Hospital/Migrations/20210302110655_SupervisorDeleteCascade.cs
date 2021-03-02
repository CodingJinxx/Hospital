using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class SupervisorDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CARE_TAKERS_CARE_TAKERS_SUPERVISOR_ID",
                table: "CARE_TAKERS");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CARE_TAKERS_CARE_TAKERS_SUPERVISOR_ID",
                table: "CARE_TAKERS",
                column: "SUPERVISOR_ID",
                principalTable: "CARE_TAKERS",
                principalColumn: "EMPLOYEE_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
