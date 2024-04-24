using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Added_AppointmentTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentType_AppointmentTypeId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentType",
                table: "AppointmentType");

            migrationBuilder.RenameTable(
                name: "AppointmentType",
                newName: "AppointmentTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentTypes",
                table: "AppointmentTypes",
                column: "AppointmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId",
                principalTable: "AppointmentTypes",
                principalColumn: "AppointmentTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentTypes_AppointmentTypeId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentTypes",
                table: "AppointmentTypes");

            migrationBuilder.RenameTable(
                name: "AppointmentTypes",
                newName: "AppointmentType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentType",
                table: "AppointmentType",
                column: "AppointmentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentType_AppointmentTypeId",
                table: "Appointments",
                column: "AppointmentTypeId",
                principalTable: "AppointmentType",
                principalColumn: "AppointmentTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
