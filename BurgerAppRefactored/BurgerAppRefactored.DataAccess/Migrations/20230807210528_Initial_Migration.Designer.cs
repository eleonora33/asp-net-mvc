﻿// <auto-generated />
using BurgerAppRefactored.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerAppRefactored.DataAccess.Migrations
{
    [DbContext(typeof(BurgerAppDbContext))]
    [Migration("20230807210528_Initial_Migration")]
    partial class Initial_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BurgerAppRefactored.Domain.Models.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("HasFries")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegetarian")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Burgers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HasFries = true,
                            IsVegan = true,
                            IsVegetarian = true,
                            Name = "Name1",
                            Price = 100.0
                        },
                        new
                        {
                            Id = 2,
                            HasFries = false,
                            IsVegan = false,
                            IsVegetarian = false,
                            Name = "Name2",
                            Price = 150.0
                        });
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.Models.BurgerOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BurgerId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BurgerId");

                    b.HasIndex("OrderId");

                    b.ToTable("BurgerOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BurgerId = 1,
                            OrderId = 2,
                            Price = 250.0,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            BurgerId = 2,
                            OrderId = 1,
                            Price = 500.0,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Vlae",
                            FullName = "Name Toso",
                            IsDelivered = true,
                            Location = "Karpos"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Vlae",
                            FullName = "Name Eleonora",
                            IsDelivered = false,
                            Location = "Karpos"
                        });
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.Models.BurgerOrder", b =>
                {
                    b.HasOne("BurgerAppRefactored.Domain.Models.Burger", "Burger")
                        .WithMany("BurgerOrders")
                        .HasForeignKey("BurgerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BurgerAppRefactored.Domain.Models.Order", "Order")
                        .WithMany("BurgerOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Burger");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.Models.Burger", b =>
                {
                    b.Navigation("BurgerOrders");
                });

            modelBuilder.Entity("BurgerAppRefactored.Domain.Models.Order", b =>
                {
                    b.Navigation("BurgerOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
