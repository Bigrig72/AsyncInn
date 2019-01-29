using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystems.Migrations
{
    public partial class UpdatedInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amentities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Half bath with blowdryer" },
                    { 2, "Full bath with blowdryer" },
                    { 3, "Breakfast" },
                    { 4, "Jetted tub" },
                    { 5, "Hot tub" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Someplace in North Denver", "Denver Mariott", "(202)-756-4556" },
                    { 2, "Someplace in Seattle", "Washington Mariott", "(750)-555-2336" },
                    { 3, "Someplace in Iowa", "Iowa Hampton Inn", "(875)-334-4557" },
                    { 4, "Someplace in North Dakota", "North Dakota Ritz", "(239)-445-3456" },
                    { 5, "Someplace in NW DC", "Washington DC Ritz", "(202)-445-3456" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "ID", "Name", "RoomAmentitiesID", "Roomlayout" },
                values: new object[,]
                {
                    { 1, "basic room", 1, 0 },
                    { 2, "basic room upgrade", 2, 1 },
                    { 3, "Luxury basic", 3, 2 },
                    { 4, "Luxury upgrade", 4, 2 },
                    { 5, "Supreme", 5, 2 },
                    { 6, "Supreme upgrade", 6, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amentities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amentities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amentities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Amentities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Amentities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Room",
                keyColumn: "ID",
                keyValue: 6);
        }
    }
}
