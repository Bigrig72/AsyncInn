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
    public class HotelRoomUnitTest
    {
        [Fact]
        public void GetHotelRoomNumber()
        {
            Hotel_Room room = new Hotel_Room();
            room.RoomNumber = 120;
            Assert.Equal(120, room.RoomNumber);
        }
        [Fact]
        public void SetHotelRoomNumber()
        {
            Hotel_Room room = new Hotel_Room();
            room.RoomNumber = 120;
            room.RoomNumber = 300;
            Assert.Equal(300, room.RoomNumber);
        }
        [Fact]
        public void GetHotelRoomID()
        {
            Hotel_Room room = new Hotel_Room();
            room.RoomID = 1;            
            Assert.Equal(1, room.RoomID);
        }
        [Fact]
        public void SetHotelRoomID()
        {
            Hotel_Room room = new Hotel_Room();
            room.RoomID = 1;
            room.RoomID = 5;
            Assert.Equal(5, room.RoomID);
        }
        [Fact]
        public void GetHotelRoomRate()
        {
            Hotel_Room room = new Hotel_Room();
            room.Rate = 100;
           
            Assert.Equal(100, room.Rate);
        }
        [Fact]
        public void SetHotelRoomRate()
        {
            Hotel_Room room = new Hotel_Room();
            room.Rate = 100;
            room.Rate = 200;

            Assert.Equal(200, room.Rate);
        }
        [Fact]
        public void GetPetFriendly()
        {
            Hotel_Room room = new Hotel_Room();
            room.PetFriendly = true;
            Assert.True(room.PetFriendly);
        }
        [Fact]
        public void NotPetFriendly()
        {
            Hotel_Room room = new Hotel_Room();
            room.PetFriendly = false;
            Assert.False(room.PetFriendly);
        }

    }
}
