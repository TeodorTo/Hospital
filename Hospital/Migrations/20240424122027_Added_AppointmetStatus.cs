using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Added_AppointmetStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentStatus_AppointmentStatusId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentStatus",
                table: "AppointmentStatus");

            migrationBuilder.RenameTable(
                name: "AppointmentStatus",
                newName: "AppointmentStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentStatuses",
                table: "AppointmentStatuses",
                column: "AppointmentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentStatuses_AppointmentStatusId",
                table: "Appointments",
                column: "AppointmentStatusId",
                principalTable: "AppointmentStatuses",
                principalColumn: "AppointmentStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentStatuses_AppointmentStatusId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentStatuses",
                table: "AppointmentStatuses");

            migrationBuilder.RenameTable(
                name: "AppointmentStatuses",
                newName: "AppointmentStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentStatus",
                table: "AppointmentStatus",
                column: "AppointmentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentStatus_AppointmentStatusId",
                table: "Appointments",
                column: "AppointmentStatusId",
                principalTable: "AppointmentStatus",
                principalColumn: "AppointmentStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
