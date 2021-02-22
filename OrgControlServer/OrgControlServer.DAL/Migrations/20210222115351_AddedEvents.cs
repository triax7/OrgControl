using Microsoft.EntityFrameworkCore.Migrations;

namespace OrgControlServer.DAL.Migrations
{
    public partial class AddedEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Zones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Roles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "Assignments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zones_EventId",
                table: "Zones",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_EventId",
                table: "Roles",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_EventId",
                table: "Assignments",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Events_EventId",
                table: "Assignments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Events_EventId",
                table: "Roles",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Events_EventId",
                table: "Zones",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Events_EventId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Events_EventId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Events_EventId",
                table: "Zones");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Zones_EventId",
                table: "Zones");

            migrationBuilder.DropIndex(
                name: "IX_Roles_EventId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_EventId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Zones");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Assignments");
        }
    }
}
