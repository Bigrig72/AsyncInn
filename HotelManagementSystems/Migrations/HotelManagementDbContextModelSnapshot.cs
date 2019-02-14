﻿// <auto-generated />
using HotelManagementSystems.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelManagementSystems.Migrations
{
    [DbContext(typeof(HotelManagementDbContext))]
    partial class HotelManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelManagementSystems.Models.Amentities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Amentities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Half bath with blowdryer"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Full bath with blowdryer"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Breakfast"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Jetted tub"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Hot tub"
                        });
                });

            modelBuilder.Entity("HotelManagementSystems.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Someplace in North Denver",
                            Name = "Denver Mariott",
                            Phone = "(202)-756-4556"
                        },
                        new
                        {
                            ID = 2,
                            Address = "Someplace in Seattle",
                            Name = "Washington Mariott",
                            Phone = "(750)-555-2336"
                        },
                        new
                        {
                            ID = 3,
                            Address = "Someplace in Iowa",
                            Name = "Iowa Hampton Inn",
                            Phone = "(875)-334-4557"
                        },
                        new
                        {
                            ID = 4,
                            Address = "Someplace in North Dakota",
                            Name = "North Dakota Ritz",
                            Phone = "(239)-445-3456"
                        },
                        new
                        {
                            ID = 5,
                            Address = "Someplace in NW DC",
                            Name = "Washington DC Ritz",
                            Phone = "(202)-445-3456"
                        });
                });

            modelBuilder.Entity("HotelManagementSystems.Models.Hotel_Room", b =>
                {
                    b.Property<int>("RoomID");

                    b.Property<int>("HotelID");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<int>("RoomNumberID");

                    b.HasKey("RoomID", "HotelID");

                    b.HasIndex("HotelID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("HotelManagementSystems.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("RoomAmentitiesID");

                    b.Property<int>("Roomlayout");

                    b.HasKey("ID");

                    b.ToTable("Room");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "basic room",
                            RoomAmentitiesID = 1,
                            Roomlayout = 1
                        },
                        new
                        {
                            ID = 2,
                            Name = "basic room upgrade",
                            RoomAmentitiesID = 2,
                            Roomlayout = 2
                        },
                        new
                        {
                            ID = 3,
                            Name = "Luxury basic",
                            RoomAmentitiesID = 3,
                            Roomlayout = 3
                        },
                        new
                        {
                            ID = 4,
                            Name = "Luxury upgrade",
                            RoomAmentitiesID = 4,
                            Roomlayout = 3
                        },
                        new
                        {
                            ID = 5,
                            Name = "Supreme",
                            RoomAmentitiesID = 5,
                            Roomlayout = 3
                        },
                        new
                        {
                            ID = 6,
                            Name = "Supreme upgrade",
                            RoomAmentitiesID = 6,
                            Roomlayout = 3
                        });
                });

            modelBuilder.Entity("HotelManagementSystems.Models.RoomAmentities", b =>
                {
                    b.Property<int>("AmentitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmentitiesID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("RoomAmentities");
                });

            modelBuilder.Entity("HotelManagementSystems.Models.Hotel_Room", b =>
                {
                    b.HasOne("HotelManagementSystems.Models.Hotel", "Hotel")
                        .WithMany("Room")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotelManagementSystems.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HotelManagementSystems.Models.RoomAmentities", b =>
                {
                    b.HasOne("HotelManagementSystems.Models.Amentities", "Amentities")
                        .WithMany("amenitiesCollection")
                        .HasForeignKey("AmentitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HotelManagementSystems.Models.Room", "Room")
                        .WithMany("RoomAmentities")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
