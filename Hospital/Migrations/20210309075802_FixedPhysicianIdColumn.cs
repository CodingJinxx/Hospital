using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class FixedPhysicianIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WARDS_PHYSICIANS_FACILITY_ID",
                table: "WARDS");

            migrationBuilder.RenameColumn(
                name: "FACILITY_ID",
                table: "WARDS",
                newName: "PHYSICIAN_ID");

            migrationBuilder.RenameIndex(
                name: "IX_WARDS_FACILITY_ID",
                table: "WARDS",
                newName: "IX_WARDS_PHYSICIAN_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WARDS_PHYSICIANS_PHYSICIAN_ID",
                table: "WARDS",
                column: "PHYSICIAN_ID",
                principalTable: "PHYSICIANS",
                principalColumn: "EMPLOYEE_ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WARDS_PHYSICIANS_PHYSICIAN_ID",
                table: "WARDS");

            migrationBuilder.RenameColumn(
                name: "PHYSICIAN_ID",
                table: "WARDS",
                newName: "FACILITY_ID");

            migrationBuilder.RenameIndex(
                name: "IX_WARDS_PHYSICIAN_ID",
                table: "WARDS",
                newName: "IX_WARDS_FACILITY_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WARDS_PHYSICIANS_FACILITY_ID",
                table: "WARDS",
                column: "FACILITY_ID",
                principalTable: "PHYSICIANS",
                principalColumn: "EMPLOYEE_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
