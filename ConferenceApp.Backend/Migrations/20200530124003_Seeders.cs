using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class Seeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionSpeaker",
                table: "SessionSpeaker");

            migrationBuilder.DropIndex(
                name: "IX_SessionSpeaker_SpeakerId",
                table: "SessionSpeaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionAttendee",
                table: "SessionAttendee");

            migrationBuilder.DropIndex(
                name: "IX_SessionAttendee_AttendeeId",
                table: "SessionAttendee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionSpeaker",
                table: "SessionSpeaker",
                columns: new[] { "SpeakerId", "SessionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionAttendee",
                table: "SessionAttendee",
                columns: new[] { "AttendeeId", "SessionId" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "ID", "Description", "EndTime", "StartTime", "Title" },
                values: new object[] { 1, null, null, null, "Keynote" });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "ID", "Bio", "Name", "Website" },
                values: new object[] { 1, "Awesome Scott", "Scott hanselman", "hanselman.com" });

            migrationBuilder.InsertData(
                table: "SessionSpeaker",
                columns: new[] { "SpeakerId", "SessionId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_SessionSpeaker_SessionId",
                table: "SessionSpeaker",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttendee_SessionId",
                table: "SessionAttendee",
                column: "SessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionSpeaker",
                table: "SessionSpeaker");

            migrationBuilder.DropIndex(
                name: "IX_SessionSpeaker_SessionId",
                table: "SessionSpeaker");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionAttendee",
                table: "SessionAttendee");

            migrationBuilder.DropIndex(
                name: "IX_SessionAttendee_SessionId",
                table: "SessionAttendee");

            migrationBuilder.DeleteData(
                table: "SessionSpeaker",
                keyColumns: new[] { "SpeakerId", "SessionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionSpeaker",
                table: "SessionSpeaker",
                columns: new[] { "SessionId", "SpeakerId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionAttendee",
                table: "SessionAttendee",
                columns: new[] { "SessionId", "AttendeeId" });

            migrationBuilder.CreateIndex(
                name: "IX_SessionSpeaker_SpeakerId",
                table: "SessionSpeaker",
                column: "SpeakerId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionAttendee_AttendeeId",
                table: "SessionAttendee",
                column: "AttendeeId");
        }
    }
}
