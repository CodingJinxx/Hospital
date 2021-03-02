using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class WardPhysicianStationJT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WARDS",
                columns: table => new
                {
                    WARD_ID = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HOSPITAL_FACILITY_ID = table.Column<int>(type: "INT", nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    CARRYING_CAPACITY = table.Column<int>(type: "INT", nullable: false),
                    LEAD_PHYSICIAN_ID = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WARDS", x => x.WARD_ID);
                    table.ForeignKey(
                        name: "FK_WARDS_HOSPITAL_FACILITIES_HOSPITAL_FACILITY_ID",
                        column: x => x.HOSPITAL_FACILITY_ID,
                        principalTable: "HOSPITAL_FACILITIES",
                        principalColumn: "FACILITY_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WARDS_PHYSICIANS_LEAD_PHYSICIAN_ID",
                        column: x => x.LEAD_PHYSICIAN_ID,
                        principalTable: "PHYSICIANS",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHYSICIAN_STATION_JT",
                columns: table => new
                {
                    PHYSICIAN_ID = table.Column<int>(type: "INT", nullable: false),
                    WARD_ID = table.Column<int>(type: "INT", nullable: false),
                    WORKING_HOURS = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHYSICIAN_STATION_JT", x => new { x.PHYSICIAN_ID, x.WARD_ID });
                    table.ForeignKey(
                        name: "FK_PHYSICIAN_STATION_JT_PHYSICIANS_PHYSICIAN_ID",
                        column: x => x.PHYSICIAN_ID,
                        principalTable: "PHYSICIANS",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PHYSICIAN_STATION_JT_WARDS_WARD_ID",
                        column: x => x.WARD_ID,
                        principalTable: "WARDS",
                        principalColumn: "WARD_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PHYSICIAN_STATION_JT_WARD_ID",
                table: "PHYSICIAN_STATION_JT",
                column: "WARD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WARDS_HOSPITAL_FACILITY_ID",
                table: "WARDS",
                column: "HOSPITAL_FACILITY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WARDS_LEAD_PHYSICIAN_ID",
                table: "WARDS",
                column: "LEAD_PHYSICIAN_ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PHYSICIAN_STATION_JT");

            migrationBuilder.DropTable(
                name: "WARDS");
        }
    }
}
