using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    public partial class Added_AppointmentStatus_AppointmentTypes_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppointmentStatuses",
                columns: new[] { "AppointmentStatusId", "Name" },
                values: new object[,]
                {
                    { 1, "Scheduled" },
                    { 2, "Cancelled" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "AppointmentTypes",
                columns: new[] { "AppointmentTypeId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Regular checkup", "Checkup" },
                    { 2, "Emergency appointment", "Emergency" },
                    { 3, "Follow-up appointment", "Follow-up" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppointmentStatuses",
                keyColumn: "AppointmentStatusId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppointmentStatuses",
                keyColumn: "AppointmentStatusId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppointmentStatuses",
                keyColumn: "AppointmentStatusId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AppointmentTypes",
                keyColumn: "AppointmentTypeId",
                keyValue: 3);
        }
    }
}
