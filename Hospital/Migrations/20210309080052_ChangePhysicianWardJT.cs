using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class ChangePhysicianWardJT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PHYSICIAN_STATION_JT_PHYSICIANS_PHYSICIAN_ID",
                table: "PHYSICIAN_STATION_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_PHYSICIAN_STATION_JT_WARDS_WARD_ID",
                table: "PHYSICIAN_STATION_JT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PHYSICIAN_STATION_JT",
                table: "PHYSICIAN_STATION_JT");

            migrationBuilder.RenameTable(
                name: "PHYSICIAN_STATION_JT",
                newName: "PHYSICIAN_WARD_JT");

            migrationBuilder.RenameIndex(
                name: "IX_PHYSICIAN_STATION_JT_WARD_ID",
                table: "PHYSICIAN_WARD_JT",
                newName: "IX_PHYSICIAN_WARD_JT_WARD_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PHYSICIAN_WARD_JT",
                table: "PHYSICIAN_WARD_JT",
                columns: new[] { "PHYSICIAN_ID", "WARD_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PHYSICIAN_WARD_JT_PHYSICIANS_PHYSICIAN_ID",
                table: "PHYSICIAN_WARD_JT",
                column: "PHYSICIAN_ID",
                principalTable: "PHYSICIANS",
                principalColumn: "EMPLOYEE_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PHYSICIAN_WARD_JT_WARDS_WARD_ID",
                table: "PHYSICIAN_WARD_JT",
                column: "WARD_ID",
                principalTable: "WARDS",
                principalColumn: "WARD_ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PHYSICIAN_WARD_JT_PHYSICIANS_PHYSICIAN_ID",
                table: "PHYSICIAN_WARD_JT");

            migrationBuilder.DropForeignKey(
                name: "FK_PHYSICIAN_WARD_JT_WARDS_WARD_ID",
                table: "PHYSICIAN_WARD_JT");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PHYSICIAN_WARD_JT",
                table: "PHYSICIAN_WARD_JT");

            migrationBuilder.RenameTable(
                name: "PHYSICIAN_WARD_JT",
                newName: "PHYSICIAN_STATION_JT");

            migrationBuilder.RenameIndex(
                name: "IX_PHYSICIAN_WARD_JT_WARD_ID",
                table: "PHYSICIAN_STATION_JT",
                newName: "IX_PHYSICIAN_STATION_JT_WARD_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PHYSICIAN_STATION_JT",
                table: "PHYSICIAN_STATION_JT",
                columns: new[] { "PHYSICIAN_ID", "WARD_ID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PHYSICIAN_STATION_JT_PHYSICIANS_PHYSICIAN_ID",
                table: "PHYSICIAN_STATION_JT",
                column: "PHYSICIAN_ID",
                principalTable: "PHYSICIANS",
                principalColumn: "EMPLOYEE_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PHYSICIAN_STATION_JT_WARDS_WARD_ID",
                table: "PHYSICIAN_STATION_JT",
                column: "WARD_ID",
                principalTable: "WARDS",
                principalColumn: "WARD_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
