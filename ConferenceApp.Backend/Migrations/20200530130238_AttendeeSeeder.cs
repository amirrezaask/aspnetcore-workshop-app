using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class AttendeeSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "Id", "EmailAddress", "FirstName", "LastName", "UserName" },
                values: new object[] { 1, "raskarpour@gmail.com", "Amirreza", "Askarpour", "amirrezaask" });

            migrationBuilder.InsertData(
                table: "SessionAttendee",
                columns: new[] { "AttendeeId", "SessionId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SessionAttendee",
                keyColumns: new[] { "AttendeeId", "SessionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Attendees",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
