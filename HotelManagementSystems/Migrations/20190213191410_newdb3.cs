using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystems.Migrations
{
    public partial class newdb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomNumber",
                table: "HotelRooms",
                newName: "RoomNumberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomNumberID",
                table: "HotelRooms",
                newName: "RoomNumber");
        }
    }
}
