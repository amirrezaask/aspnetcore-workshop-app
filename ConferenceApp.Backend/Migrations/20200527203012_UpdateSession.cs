using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class UpdateSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Tracks_TrackID",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_TrackID",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "Abstract",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TrackID",
                table: "Sessions");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sessions",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sessions");

            migrationBuilder.AddColumn<string>(
                name: "Abstract",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrackID",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TrackID",
                table: "Sessions",
                column: "TrackID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Tracks_TrackID",
                table: "Sessions",
                column: "TrackID",
                principalTable: "Tracks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
