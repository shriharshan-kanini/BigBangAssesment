﻿// <auto-generated />
using System;
using BigBangAssesment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BigBangAssesment.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20230527091813_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BigBangAssesment.Model.Booking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingId"));

                    b.Property<DateTime>("BookedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CheckInDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CheckOut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("BookingId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("HotelId");

                    b.HasIndex("RoomId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CustomerNumber")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("HotelId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Employee", b =>
                {
                    b.Property<int?>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("EmployeeId"));

                    b.Property<string>("EmployeeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("HotelId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HotelId"));

                    b.Property<string>("HotelDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"));

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomId");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BigBangAssesment.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Booking", b =>
                {
                    b.HasOne("BigBangAssesment.Model.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerId");

                    b.HasOne("BigBangAssesment.Model.Hotel", "Hotel")
                        .WithMany("Bookings")
                        .HasForeignKey("HotelId");

                    b.HasOne("BigBangAssesment.Model.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId");

                    b.Navigation("Customer");

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Customer", b =>
                {
                    b.HasOne("BigBangAssesment.Model.Hotel", "Hotel")
                        .WithMany("Customers")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Employee", b =>
                {
                    b.HasOne("BigBangAssesment.Model.Hotel", "Hotel")
                        .WithMany("Employees")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Room", b =>
                {
                    b.HasOne("BigBangAssesment.Model.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Hotel", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Customers");

                    b.Navigation("Employees");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("BigBangAssesment.Model.Room", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
