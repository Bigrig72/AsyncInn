using HotelManagementSystems.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystems.Data
{
    public class HotelManagementDbContext: DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options):base(options)
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
        }
        

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Hotel_Room> HotelRooms { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Amentities> Amentities { get; set; }
        public DbSet<RoomAmentities> RoomAmentities { get; set; }

    }
}
