﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parkz;

#nullable disable

namespace Parkz.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class DemoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Parkz.Models.AdressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HouseNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Parkz.Models.CarModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarColor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extras")
                        .HasColumnType("TEXT");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("RecommendedPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Parkz.Models.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdressId")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Parkz.Models.PurchaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CarId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerModelId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("PricePaid")
                        .HasColumnType("REAL");

                    b.Property<int>("SalesPersonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerModelId");

                    b.HasIndex("SalesPersonId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Parkz.Models.SalesPersonModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AdressId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("JobTitle")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Salary")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("SalesPeople");
                });

            modelBuilder.Entity("Parkz.Models.CustomerModel", b =>
                {
                    b.HasOne("Parkz.Models.AdressModel", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Parkz.Models.PurchaseModel", b =>
                {
                    b.HasOne("Parkz.Models.CarModel", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Parkz.Models.CustomerModel", null)
                        .WithMany("purchases")
                        .HasForeignKey("CustomerModelId");

                    b.HasOne("Parkz.Models.SalesPersonModel", "SalesPerson")
                        .WithMany()
                        .HasForeignKey("SalesPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("SalesPerson");
                });

            modelBuilder.Entity("Parkz.Models.SalesPersonModel", b =>
                {
                    b.HasOne("Parkz.Models.AdressModel", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Parkz.Models.CustomerModel", b =>
                {
                    b.Navigation("purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
