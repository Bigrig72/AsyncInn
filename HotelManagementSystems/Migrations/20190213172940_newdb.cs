using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagementSystems.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amentities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amentities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomAmentitiesID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Roomlayout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => new { x.RoomID, x.HotelID });
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmentities",
                columns: table => new
                {
                    AmentitiesID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmentities", x => new { x.AmentitiesID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_RoomAmentities_Amentities_AmentitiesID",
                        column: x => x.AmentitiesID,
                        principalTable: "Amentities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmentities_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, "basic room", 1, 1 },
                    { 2, "basic room upgrade", 2, 2 },
                    { 3, "Luxury basic", 3, 3 },
                    { 4, "Luxury upgrade", 4, 3 },
                    { 5, "Supreme", 5, 3 },
                    { 6, "Supreme upgrade", 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelID",
                table: "HotelRooms",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmentities_RoomID",
                table: "RoomAmentities",
                column: "RoomID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "RoomAmentities");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Amentities");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
