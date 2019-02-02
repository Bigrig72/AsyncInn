using System;
using Xunit;
using HotelManagementSystems.Models;
using HotelManagementSystems.Controllers;
using HotelManagementSystems.Data;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystems.Models.Services;
using System.Linq;

namespace HotelTesting
{
    public class HotelUnitTest
    {/// <summary>
    /// Getter and setter tests for all of the Hotel properties
    /// </summary>
        [Fact]
        public void GetHotelName()
        {
            Hotel HamptonInn = new Hotel();
            HamptonInn.Name = "HamptonInn";
            Assert.Equal("HamptonInn", HamptonInn.Name);
        }
        [Fact]
        public void SetHotelName()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "HamptonInn";
            hotel.Name = "Marriot";
            Assert.Equal("Marriot", hotel.Name);
        }
        [Fact]
        public void GetHotelAddress()
        {
            Hotel HamptonInn = new Hotel();
            HamptonInn.Address = "253 Comadore ln NW VA";
            Assert.Equal("253 Comadore ln NW VA", HamptonInn.Address);
        }
        [Fact]
        public void SetHotelAddress()
        {
            Hotel HamptonInn = new Hotel();
            HamptonInn.Address = "253 Comadore ln NW VA";
            HamptonInn.Address = "400 Comadore ln NW VA";
            Assert.Equal("400 Comadore ln NW VA", HamptonInn.Address);
        }
        [Fact]
        public void GetHotelPhone()
        {
            Hotel HamptonInn = new Hotel();
            HamptonInn.Phone = "(253)-456-4554";
            Assert.Equal("(253)-456-4554", HamptonInn.Phone);
        }
        [Fact]
        public void SetHotelPhone()
        {
            Hotel HamptonInn = new Hotel();
            HamptonInn.Phone = "(253)-456-4554";
            HamptonInn.Phone = "(545)-456-4554";
            Assert.Equal("(545)-456-4554", HamptonInn.Phone);
        }
        [Fact]
        public void CheckingHotelUniqueID()
        {
            Hotel HamptonInn = new Hotel();
            HamptonInn.ID = 1;
            Assert.Equal(1, HamptonInn.ID);
        }
        /// <summary>
        /// Showing we can create a hotel and finding it in the database
        /// </summary>
        [Fact]       
        public async void CanCreateHotel()
        {
            DbContextOptions<HotelManagementDbContext> options =
                new DbContextOptionsBuilder<HotelManagementDbContext>
                ().UseInMemoryDatabase("CreateHotel").Options;

            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
            {
                // arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Marriot";
                hotel.Address = "123 walnut farms pky";
                hotel.Phone = "(323)333-4454";
                // Act
                HotelManagementService hotelService = new HotelManagementService(context);

                await hotelService.CreateHotel(hotel);
                var result = context.Hotels.FirstOrDefault(h => h.ID == hotel.ID);
                // Assert
                Assert.Equal(hotel, result);

            }
        }
        /// <summary>
        /// This proves we can delete a created hotel. One test is all I can think of to prove we can destroy.
        /// </summary>
        [Fact]
        public async void CanDeleteHotel()
        {
            DbContextOptions<HotelManagementDbContext> options =
                new DbContextOptionsBuilder<HotelManagementDbContext>
                ().UseInMemoryDatabase("DeleteHotel").Options;

            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
            {
                // arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Marriot";
                hotel.Address = "123 walnut farms pky";
                hotel.Phone = "(323)333-4454";

                Hotel hotel2 = new Hotel();
                hotel2.ID = 2;
                hotel2.Name = "Ritz";
                hotel2.Address = "555 walnut farms pky";
                hotel2.Phone = "(323)333-5555";

                // Act
                HotelManagementService hotelService = new HotelManagementService(context);
                await hotelService.CreateHotel(hotel2);
                hotelService.DeleteHotel(hotel2);
                var deleted = context.Hotels.FirstOrDefault(r => r.ID == hotel2.ID);
                Assert.Null(deleted);
            }
        }
        /// <summary>
        /// Showing we can update a hotel that has already been made with set properties
        /// </summary>
        [Fact]
        public async void CanUpdateHotelName()
        {
            DbContextOptions<HotelManagementDbContext> options =
                new DbContextOptionsBuilder<HotelManagementDbContext>
                ().UseInMemoryDatabase("DeleteHotel").Options;

            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
            {
                // arrange
                Hotel hotelA = new Hotel();
                hotelA.ID = 1;
                hotelA.Name = "Marriot";
                hotelA.Address = "123 walnut farms pky";
                hotelA.Phone = "(323)333-4454";

                // Act
                HotelManagementService hotelService = new HotelManagementService(context);
                await hotelService.CreateHotel(hotelA);
                hotelA.Name = "the ritz carlton";
                hotelService.UpdateHotel(hotelA);

                // Assert
                Assert.Equal("the ritz carlton", hotelA.Name);
            }
        }
        /// <summary>
        /// Showing we can update a hotels address
        /// </summary>
        [Fact]
        public async void CanUpdateHotelAddress()
        {
            DbContextOptions<HotelManagementDbContext> options =
                new DbContextOptionsBuilder<HotelManagementDbContext>
                ().UseInMemoryDatabase("DeleteHotel").Options;

            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
            {
                // arrange
                Hotel hotelA = new Hotel();
                hotelA.ID = 1;
                hotelA.Name = "Marriot";
                hotelA.Address = "123 walnut farms pky";
                hotelA.Phone = "(323)333-4454";

                // Act
                HotelManagementService hotelService = new HotelManagementService(context);
                await hotelService.CreateHotel(hotelA);
                hotelA.Address = "150 walnut farms pky";
                hotelService.UpdateHotel(hotelA);

                // Assert
                Assert.Equal("150 walnut farms pky", hotelA.Address);
            }
        }
    }
}
