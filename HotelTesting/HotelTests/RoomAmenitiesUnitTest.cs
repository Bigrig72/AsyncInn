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
    public class RoomAmenitiesUnitTest
    {
        [Fact]
        public void GetAmenityID()
        {
            RoomAmentities amenity = new RoomAmentities();
            amenity.AmentitiesID = 5;
            Assert.Equal(5, amenity.AmentitiesID);
        }
        [Fact]
        public void SetAmenityID()
        {
            RoomAmentities amenity = new RoomAmentities();
            amenity.AmentitiesID = 5;
            amenity.AmentitiesID = 15;
            Assert.Equal(15, amenity.AmentitiesID);
        }
        [Fact]
        public void GetRoomAmenityID()
        {
            RoomAmentities amenity = new RoomAmentities();
            amenity.RoomID = 5;          
            Assert.Equal(5, amenity.RoomID);
        }
        [Fact]
        public void SetRoomAmenityID()
        {
            RoomAmentities amenity = new RoomAmentities();
            amenity.RoomID = 5;
            amenity.RoomID = 7;
            Assert.Equal(7, amenity.RoomID);
        }

    }
}
