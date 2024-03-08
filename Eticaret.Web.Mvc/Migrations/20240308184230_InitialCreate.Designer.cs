﻿// <auto-generated />
using System;
using Eticaret.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Eticaret.Web.Mvc.Migrations
{
    [DbContext(typeof(EticaretDbContext))]
    [Migration("20240308184230_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Eticaret.Domain.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("Eticaret.Domain.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Eticaret.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasMaxLength(6)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("IconCssClass")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "pink",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(4980),
                            IconCssClass = "",
                            Name = "dress"
                        },
                        new
                        {
                            Id = 2,
                            Color = "red",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5010),
                            IconCssClass = "",
                            Name = "jean"
                        },
                        new
                        {
                            Id = 3,
                            Color = "blue",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5010),
                            IconCssClass = "",
                            Name = "Sweatshirt"
                        },
                        new
                        {
                            Id = 4,
                            Color = "yellow",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5010),
                            IconCssClass = "",
                            Name = "Sweatpants"
                        },
                        new
                        {
                            Id = 5,
                            Color = "black",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5020),
                            IconCssClass = "",
                            Name = "Jumper"
                        },
                        new
                        {
                            Id = 6,
                            Color = "white",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5020),
                            IconCssClass = "",
                            Name = "Cardigan"
                        },
                        new
                        {
                            Id = 7,
                            Color = "gray",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5020),
                            IconCssClass = "",
                            Name = "Outerwear"
                        },
                        new
                        {
                            Id = 8,
                            Color = "darkred",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5020),
                            IconCssClass = "",
                            Name = "Trousers"
                        },
                        new
                        {
                            Id = 9,
                            Color = "blue",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5020),
                            IconCssClass = "",
                            Name = "Shirt"
                        },
                        new
                        {
                            Id = 10,
                            Color = "white",
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5020),
                            IconCssClass = "",
                            Name = "T-shirt"
                        });
                });

            modelBuilder.Entity("Eticaret.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderCode")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Eticaret.Domain.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Eticaret.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int>("SellerId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("StockAmount")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Eticaret.Domain.ProductComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("StarCount")
                        .HasMaxLength(5)
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductComment");
                });

            modelBuilder.Entity("Eticaret.Domain.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SellerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SellerId");

                    b.ToTable("ProductImage");
                });

            modelBuilder.Entity("Eticaret.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5060),
                            Name = "seller"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5060),
                            Name = "buyer"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5070),
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("Eticaret.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CartId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 3, 8, 21, 42, 30, 174, DateTimeKind.Local).AddTicks(5080),
                            Email = "ays@ayd.com",
                            Enabled = true,
                            FirstName = "Ayşenur",
                            LastName = "Aydın",
                            Password = "123456",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("Eticaret.Domain.Seller", b =>
                {
                    b.HasBaseType("Eticaret.Domain.User");

                    b.Property<string>("Adress")
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<long>("CallNumber")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Seller");
                });

            modelBuilder.Entity("Eticaret.Domain.CartItem", b =>
                {
                    b.HasOne("Eticaret.Domain.Cart", null)
                        .WithMany("CartItems")
                        .HasForeignKey("CartId");

                    b.HasOne("Eticaret.Domain.Product", "ProductFk")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductFk");
                });

            modelBuilder.Entity("Eticaret.Domain.Order", b =>
                {
                    b.HasOne("Eticaret.Domain.User", "UserFk")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserFk");
                });

            modelBuilder.Entity("Eticaret.Domain.OrderItem", b =>
                {
                    b.HasOne("Eticaret.Domain.Order", "OrderFk")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eticaret.Domain.Product", "ProductFk")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderFk");

                    b.Navigation("ProductFk");
                });

            modelBuilder.Entity("Eticaret.Domain.Product", b =>
                {
                    b.HasOne("Eticaret.Domain.Category", "CategoryFk")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eticaret.Domain.Seller", "SellerFk")
                        .WithMany("Products")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryFk");

                    b.Navigation("SellerFk");
                });

            modelBuilder.Entity("Eticaret.Domain.ProductComment", b =>
                {
                    b.HasOne("Eticaret.Domain.Product", "ProductFk")
                        .WithMany("ProductComments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eticaret.Domain.User", "UserFk")
                        .WithMany("ProductComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductFk");

                    b.Navigation("UserFk");
                });

            modelBuilder.Entity("Eticaret.Domain.ProductImage", b =>
                {
                    b.HasOne("Eticaret.Domain.Product", "ProductFk")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eticaret.Domain.Seller", null)
                        .WithMany("ProductImages")
                        .HasForeignKey("SellerId");

                    b.Navigation("ProductFk");
                });

            modelBuilder.Entity("Eticaret.Domain.User", b =>
                {
                    b.HasOne("Eticaret.Domain.Cart", "CartFk")
                        .WithMany()
                        .HasForeignKey("CartId");

                    b.HasOne("Eticaret.Domain.Role", "RoleFk")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartFk");

                    b.Navigation("RoleFk");
                });

            modelBuilder.Entity("Eticaret.Domain.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Eticaret.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Eticaret.Domain.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Eticaret.Domain.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderItems");

                    b.Navigation("ProductComments");
                });

            modelBuilder.Entity("Eticaret.Domain.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Eticaret.Domain.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("ProductComments");
                });

            modelBuilder.Entity("Eticaret.Domain.Seller", b =>
                {
                    b.Navigation("ProductImages");

                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
