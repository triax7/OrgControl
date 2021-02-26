using Microsoft.EntityFrameworkCore.Migrations;

namespace OrgControlServer.DAL.Migrations
{
    public partial class CascadeFromEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Events_EventId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Events_EventId",
                table: "Zones");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Events_EventId",
                table: "Assignments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zones_Events_EventId",
                table: "Zones",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Events_EventId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Zones_Events_EventId",
                table: "Zones");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Events_EventId",
                table: "Assignments",
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
    }
}
