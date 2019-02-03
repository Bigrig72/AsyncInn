using System;
using Xunit;
using HotelManagementSystems.Models;
using HotelManagementSystems.Controllers;
using HotelManagementSystems.Data;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystems.Models.Services;
using System.Linq;

namespace HotelTesting.HotelTests
{
    public class RoomIUnitTest
    {
        /// <summary>
        /// Getter and seters for Room
        /// </summary>
        [Fact]
        public void GetRoomId()
        {
            Room roomA = new Room();
            roomA.ID = 1;
            Assert.Equal(1, roomA.ID);
        }
        [Fact]
        public void SetRoomId()
        {
            Room roomA = new Room();
            roomA.ID = 1;
            roomA.ID = 2;
            Assert.Equal(2, roomA.ID);
        }
        [Fact]
        public void GetRoomName()
        {
            Room roomA = new Room();
            roomA.Name = "standard";
            Assert.Equal("standard", roomA.Name);
        }
        [Fact]
        public void SetRoomName()
        {
            Room roomA = new Room();
            roomA.Name = "standard";
            roomA.Name = "Big";
            Assert.Equal("Big", roomA.Name);
        }
        [Fact]
        public void GetRoomAmenitiesID()
        {
            Room roomA = new Room();
            roomA.RoomAmentitiesID = 1;
            Assert.Equal(1, roomA.RoomAmentitiesID);
        }
        [Fact]
        public void SetRoomAmenitiesID()
        {
            Room roomA = new Room();
            roomA.RoomAmentitiesID = 1;
            roomA.RoomAmentitiesID = 2;
            Assert.Equal(2, roomA.RoomAmentitiesID);
        }
        [Fact]
        public async void CanCreateRoom()
        {
            DbContextOptions<HotelManagementDbContext> options =
                new DbContextOptionsBuilder<HotelManagementDbContext>
                ().UseInMemoryDatabase("RoomAmenity").Options;

            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
            {
                // arrange
                Room roomA = new Room();
                roomA.ID = 1;
                roomA.Name = "basic";
                roomA.RoomAmentitiesID = 1;
                               

                // Act
                RoomManagementService Service = new RoomManagementService(context);
                await Service.CreateRoom(roomA);
                var result = context.Room.Any(h => h.Name == roomA.Name);


                // Assert
                Assert.True(result);
            }

        }
        [Fact]
        public async void CanUpdateRoom()
        {
            DbContextOptions<HotelManagementDbContext> options =
                new DbContextOptionsBuilder<HotelManagementDbContext>
                ().UseInMemoryDatabase("RoomAmenity").Options;

            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
            {
                // arrange
                Room roomA = new Room();
                roomA.ID = 1;
                roomA.Name = "basic";
                roomA.RoomAmentitiesID = 1;


                // Act
                RoomManagementService Service = new RoomManagementService(context);
                await Service.CreateRoom(roomA);
                roomA.RoomAmentitiesID = 2;
                Service.UpdateRoom(roomA);
             


                // Assert
                Assert.Equal(2, roomA.RoomAmentitiesID);
            }

        }
        [Fact]
        public async void CanDeleteRoom()
        {
            DbContextOptions<HotelManagementDbContext> options =
                new DbContextOptionsBuilder<HotelManagementDbContext>
                ().UseInMemoryDatabase("DeleteRoom").Options;

            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
            {
                // arrange
                Room roomA = new Room();
                roomA.ID = 1;
                roomA.Name = "basic";
                roomA.RoomAmentitiesID = 1;


                // Act
                RoomManagementService Service = new RoomManagementService(context);
                await Service.CreateRoom(roomA);

                Service.DeleteRoom(roomA);
                var result = context.Room.FirstOrDefault(m => m.ID == roomA.ID);


                // Assert
                Assert.Null(result);
            }

        }

    }
}
    
