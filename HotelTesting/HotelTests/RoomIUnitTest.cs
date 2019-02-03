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
        /// <summary>
        /// Testing we can set the room id to what we want
        /// </summary>
        [Fact]
        public void SetRoomId()
        {
            Room roomA = new Room();
            roomA.ID = 1;
            roomA.ID = 2;
            Assert.Equal(2, roomA.ID);
        }
        /// <summary>
        /// testing we can get a room name
        /// </summary>
        [Fact]
        public void GetRoomName()
        {
            Room roomA = new Room();
            roomA.Name = "standard";
            Assert.Equal("standard", roomA.Name);
        }
        /// <summary>
        /// testing we can change that name
        /// </summary>
        [Fact]
        public void SetRoomName()
        {
            Room roomA = new Room();
            roomA.Name = "standard";
            roomA.Name = "Big";
            Assert.Equal("Big", roomA.Name);
        }
        /// <summary>
        /// Testing we can get room amenities id 
        /// </summary>
        [Fact]
        public void GetRoomAmenitiesID()
        {
            Room roomA = new Room();
            roomA.RoomAmentitiesID = 1;
            Assert.Equal(1, roomA.RoomAmentitiesID);
        }
        /// <summary>
        /// Testing we can chamnge the room amenities id
        /// </summary>
        [Fact]
        public void SetRoomAmenitiesID()
        {
            Room roomA = new Room();
            roomA.RoomAmentitiesID = 1;
            roomA.RoomAmentitiesID = 2;
            Assert.Equal(2, roomA.RoomAmentitiesID);
        }
        /// <summary>
        /// testing we can create a room
        /// </summary>
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
        /// <summary>
        /// Testing our update, to be able to change and then update the room
        /// </summary>
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
        /// <summary>
        /// showing we can destroy that room
        /// </summary>
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
    
