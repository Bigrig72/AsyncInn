//using System;
//using Xunit;
//using HotelManagementSystems.Models;
//using HotelManagementSystems.Controllers;
//using HotelManagementSystems.Data;
//using Microsoft.EntityFrameworkCore;
//using HotelManagementSystems.Models.Services;
//using System.Linq;

//namespace HotelTesting.HotelTests
//{
//    public class AmenitiesUnitTest
//    {
//        /// <summary>
//        /// Testing we can get an Id for the amenity
//        /// </summary>
//        [Fact]
//        public void GetID()
//        {
//            Amentities amenity = new Amentities();
//            amenity.ID = 1;
//            Assert.Equal(1, amenity.ID);
//        }
//        /// <summary>
//        /// Testing we can change that ID
//        /// </summary>
//        [Fact]
//        public void SetID()
//        {
//            Amentities amenity = new Amentities();
//            amenity.ID = 1;
//            amenity.ID = 2;
//            Assert.Equal(2, amenity.ID);
//        }
//        /// <summary>
//        /// Testing we can get an amenity name
//        /// </summary>
//        [Fact]
//        public void GetName()
//        {
//            Amentities amenity = new Amentities();
//            amenity.Name = "HotTub";
          
//            Assert.Equal("HotTub", amenity.Name);
//        }
//        /// <summary>
//        /// Testing we can change a name
//        /// </summary>
//        [Fact]
//        public void SetName()
//        {
//            Amentities amenity = new Amentities();
//            amenity.Name = "HotTub";
//            amenity.Name = "JetTub";
//            Assert.Equal("JetTub", amenity.Name);
//        }
//        /// <summary>
//        /// Testing we cn create an amenity 
//        /// </summary>
//        [Fact]
//        public async void CanCreateAmenity()
//        {
//            DbContextOptions<HotelManagementDbContext> options =
//                new DbContextOptionsBuilder<HotelManagementDbContext>
//                ().UseInMemoryDatabase("CreateAmenity").Options;

//            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
//            {
//                // arrange
//                Amentities amenity = new Amentities();
//                amenity.ID = 1;
//                amenity.Name = "HotTub";
             
//                AmenityManagementService service = new AmenityManagementService(context);
//                await service.CreateAmenity(amenity);

//                var result = context.Amentities.FirstOrDefault(h => h.ID == amenity.ID);
//                // Assert
//                Assert.Equal(amenity, result);

//            }
//        }
//        /// <summary>
//        /// Testing to verify we can update an amenity
//        /// </summary>
//        [Fact]
//        public async void CanUpdateAmenity()
//        {
//            DbContextOptions<HotelManagementDbContext> options =
//                new DbContextOptionsBuilder<HotelManagementDbContext>
//                ().UseInMemoryDatabase("RoomAmenity").Options;

//            using (HotelManagementDbContext context = new HotelManagementDbContext(options))
//            {
//                // arrange
//                Amentities amenity = new Amentities();
//                amenity.ID = 1;
//                amenity.Name = "HotTub";             
//                // Act
//                AmenityManagementService Service = new AmenityManagementService(context);
//                await Service.CreateAmenity(amenity);
//                amenity.Name = "JetTub";
//                Service.UpdateAmenity(amenity);
//                // Assert
//                Assert.Equal("JetTub", amenity.Name);
//            }
//        }
        /// <summary>
        /// Ensuring we can destroy an amenity
        /// </summary>
        //[Fact]
        //public async void CanDeleteAmenity()
        //{
        //    DbContextOptions<HotelManagementDbContext> options =
        //        new DbContextOptionsBuilder<HotelManagementDbContext>
        //        ().UseInMemoryDatabase("RoomAmenity").Options;

        //    using (HotelManagementDbContext context = new HotelManagementDbContext(options))
        //    {
        //        // arrange
        //        Amentities amenity = new Amentities();
        //        amenity.ID = 1;
        //        amenity.Name = "HotTub";
        //        // Act
        //        AmenityManagementService Service = new AmenityManagementService(context);
        //        await Service.CreateAmenity(amenity);
        //        Service.DeleteAmenity(amenity);

        //        var delete = context.Amentities.FirstOrDefault(m => m.Name == amenity.Name);
               
        //        // Assert
        //        Assert.Null(delete);
        //    }

        //}
//    }
//}
