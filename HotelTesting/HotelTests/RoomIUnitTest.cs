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
        public void GetRoomName()
        {
            Room roomA = new Room();
            roomA.Name = "standard";
            Assert.Equal("standard", roomA.Name);
        }
        [Fact]
        public void GetRoomAmenityFromAmenitites()
        {
            Room roomA = new Room();
            roomA.RoomAmentities.Amentities.Name = "Microwave";
            Assert.Equal("Microwave", roomA.RoomAmentities.Amentities.Name);
        }

    }
}
