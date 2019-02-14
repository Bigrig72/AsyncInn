using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystems.Migrations
{
    public partial class newdb5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomAmentities_RoomID",
                table: "RoomAmentities");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmentities_RoomID",
                table: "RoomAmentities",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RoomAmentities_RoomID",
                table: "RoomAmentities");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmentities_RoomID",
                table: "RoomAmentities",
                column: "RoomID",
                unique: true);
        }
    }
}
