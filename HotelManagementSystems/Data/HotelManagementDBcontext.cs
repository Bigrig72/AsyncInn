using HotelManagementSystems.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystems.Data
{
    public class HotelManagementDbContext : DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add our composite key associations
            modelBuilder.Entity<Hotel_Room>().HasKey(ce => new
            {
                ce.RoomID,
                ce.HotelID
            });
            modelBuilder.Entity<RoomAmentities>().HasKey(ce => new
            {
                ce.AmentitiesID,
                ce.RoomID
            });

         modelBuilder.Entity<Hotel>().HasData(
               new Hotel
                {
                    ID = 1,
                    Name = "Denver Mariott",
                    Phone = "(202)-756-4556",
                    Address = "Someplace in North Denver"

                },
               new Hotel
                 {
                     ID = 2,
                     Name = "Washington Mariott",
                     Phone = "(750)-555-2336",
                     Address = "Someplace in Seattle"

                 },
               new Hotel
                   {
                       ID = 3,
                       Name = "Iowa Hampton Inn",
                       Phone = "(875)-334-4557",
                       Address = "Someplace in Iowa"

                   },
               new Hotel
                     {
                         ID = 4,
                         Name = "North Dakota Ritz",
                         Phone = "(239)-445-3456",
                         Address = "Someplace in North Dakota"

                     },
               new Hotel
                       {
                           ID = 5,
                           Name = "Washington DC Ritz",
                           Phone = "(202)-445-3456",
                           Address = "Someplace in NW DC"

                       });

         modelBuilder.Entity<Room>().HasData(
               new Room
               {
                   ID = 1,
                   Name = "basic room",
                   RoomAmentitiesID = 1,
                   Roomlayout = Layout.Studio
               },
               new Room
               {
                   ID = 2,
                   Name = "basic room upgrade",
                   RoomAmentitiesID = 2,
                   Roomlayout = Layout.OneBedroom
               },
               new Room
               {
                   ID = 3,
                   Name = "Luxury basic",
                   RoomAmentitiesID = 3,
                   Roomlayout = Layout.TwoBedroom
               },
               new Room
               {
                   ID = 4,
                   Name = "Luxury upgrade",
                   RoomAmentitiesID = 4,
                   Roomlayout = Layout.TwoBedroom
               },
               new Room
               {
                   ID = 5,
                   Name = "Supreme",
                   RoomAmentitiesID = 5,
                   Roomlayout = Layout.TwoBedroom
               },
               new Room
               {
                   ID = 6,
                   Name = "Supreme upgrade",
                   RoomAmentitiesID = 6,
                   Roomlayout = Layout.TwoBedroom
               });

            modelBuilder.Entity<Amentities>().HasData(
               new Amentities
                    {
                        Name = "Half bath with blowdryer",
                        ID = 1
                    },
               new Amentities
                      {
                          Name = "Full bath with blowdryer",
                          ID = 2
                      },
               new Amentities
                        {
                            Name = "Breakfast",
                            ID = 3
                        },
               new Amentities
                          {
                              Name = "Jetted tub",
                              ID = 4
                          },
               new Amentities
                            {
                                Name = "Hot tub",
                                ID = 5
                            });
        }


        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Hotel_Room> HotelRooms { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Amentities> Amentities { get; set; }
        public DbSet<RoomAmentities> RoomAmentities { get; set; }

    }
}
