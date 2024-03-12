﻿// <auto-generated />
using System;
using CoffeeSubscriptionManager.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoffeeSubscriptionManager.DAL.Migrations
{
    [DbContext(typeof(CoffeeSubscriptionContext))]
    partial class CoffeeSubscriptionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.Accessory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("StockCount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.Coffee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coffees");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.CoffeeBatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BatchDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("BatchNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CoffeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeId");

                    b.ToTable("CoffeeBatches");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.ContactPreference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Email")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Mail")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SMS")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("ContactPreferences");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstLineOfAddress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondLineOfAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.GrindSize", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CoffeeBatchId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeBatchId");

                    b.ToTable("GrindSizes");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddedExtrasId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSent")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("ScheduledSendDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AddedExtrasId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BaseOrderPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("CoffeeBatchId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("FrequencyInDays")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GrindSizeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("NextSendDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderSize")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CoffeeBatchId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("GrindSizeId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.CoffeeBatch", b =>
                {
                    b.HasOne("CoffeeSubscriptionManager.Models.Coffee", "Coffee")
                        .WithMany()
                        .HasForeignKey("CoffeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coffee");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.ContactPreference", b =>
                {
                    b.HasOne("CoffeeSubscriptionManager.Models.Customer", null)
                        .WithMany("ContactPreferences")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.GrindSize", b =>
                {
                    b.HasOne("CoffeeSubscriptionManager.Models.CoffeeBatch", null)
                        .WithMany("GrindSizesAvailable")
                        .HasForeignKey("CoffeeBatchId");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.Order", b =>
                {
                    b.HasOne("CoffeeSubscriptionManager.Models.Accessory", "AddedExtras")
                        .WithMany()
                        .HasForeignKey("AddedExtrasId");

                    b.HasOne("CoffeeSubscriptionManager.Models.Subscription", "Subscription")
                        .WithMany()
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedExtras");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.Subscription", b =>
                {
                    b.HasOne("CoffeeSubscriptionManager.Models.CoffeeBatch", "CoffeeBatch")
                        .WithMany()
                        .HasForeignKey("CoffeeBatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeSubscriptionManager.Models.Customer", "Customer")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoffeeSubscriptionManager.Models.GrindSize", "GrindSize")
                        .WithMany()
                        .HasForeignKey("GrindSizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoffeeBatch");

                    b.Navigation("Customer");

                    b.Navigation("GrindSize");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.CoffeeBatch", b =>
                {
                    b.Navigation("GrindSizesAvailable");
                });

            modelBuilder.Entity("CoffeeSubscriptionManager.Models.Customer", b =>
                {
                    b.Navigation("ContactPreferences");

                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
