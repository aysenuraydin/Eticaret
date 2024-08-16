﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eticaret.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    IconCssClass = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderCode = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    StockAmount = table.Column<byte>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<byte>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<byte>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    StarCount = table.Column<byte>(type: "INTEGER", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedAt", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(860), "seller", "SELLER" },
                    { 2, null, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(900), "buyer", "BUYER" },
                    { 3, null, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(900), "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "IconCssClass", "Name" },
                values: new object[,]
                {
                    { 1, "	#a4b2b0", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1170), null, "Yelek" },
                    { 2, "	#896863	", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1180), null, "Triko" },
                    { 3, "#C27D42	", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1180), null, "Sweatshirt" },
                    { 4, "	#BF8882	", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1190), null, "Şort" },
                    { 5, "	#A4B2B0	", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1190), null, "Kazak" },
                    { 6, "#828DE5", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1190), null, "Elbise" },
                    { 7, "#595B56	", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1190), null, "Ceket" },
                    { 8, "	#CDC6C3	", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1200), null, "Pantolon" },
                    { 9, "#DEBDB0", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1200), null, "Etek" },
                    { 10, "	#BE969B	", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1200), null, "Bluz" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "Enabled", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "cea9463c-bb26-4360-aad3-c4f359093f1b", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(980), "aysenur@aydin.com", false, true, "Admin", "Admin", false, null, null, null, "123456", null, false, 3, null, false, null },
                    { 2, 0, "849480e9-c0cf-42a1-a7c7-e3bc0ce9e811", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1040), "ays2@ayd.com", false, true, "Ayşenur4", "Aydın4", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 3, 0, "6147f052-ff88-4125-9f5d-31fb441415a3", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1050), "ays3@ayd.com", false, true, "Ayşenur5", "Aydın5", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 4, 0, "a07d054d-2036-48e6-8ce9-8245dfee0ec0", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1050), "ays4@ayd.com", false, true, "Ayşenur6", "Aydın6", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 5, 0, "31893ec7-99c8-4c55-8532-61ff1d49aca7", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1060), "ays5@ayd.com", false, true, "Ayşenur7", "Aydın7", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 6, 0, "4d479d0b-55a6-4747-9e9b-65874513fbee", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1070), "ays6@ayd.com", false, true, "Ayşenur4", "Aydın4", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 7, 0, "0ce3f479-7c00-4220-9ca7-a9d0fef80e98", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1080), "ays7@ayd.com", false, true, "Ayşenur5", "Aydın5", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 8, 0, "5ea2d9a2-0db5-4e08-a1a9-1e2cb32b678a", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1090), "ays8@ayd.com", false, true, "Ayşenur6", "Aydın6", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 9, 0, "6b1c2758-1b8e-4096-965b-dc9f778c4a3a", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1100), "ays9@ayd.com", false, true, "Ayşenur7", "Aydın7", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 10, 0, "d671f2f7-97ba-42e3-bead-9b9872db157b", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1110), "ays10@ayd.com", false, true, "Ayşenur2", "Aydın2", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 11, 0, "9d276e30-ddc0-491a-9add-2cdd176ba5a2", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1110), "ays11@ayd.com", false, true, "Ayşenur5", "Aydın5", false, null, null, null, "123456", null, false, 1, null, false, null },
                    { 12, 0, "d80e6b07-12c2-4189-b27c-cca60c3562a3", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1120), "ays12@ayd.com", false, true, "Ayşenur6", "Aydın6", false, null, null, null, "123456", null, false, 1, null, false, null },
                    { 13, 0, "c084b3e0-6a55-4d44-b394-c0eb4e494174", new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1130), "ays13@ayd.com", false, true, "Ayşenur7", "Aydın7", false, null, null, null, "123456", null, false, 1, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Details", "Enabled", "IsConfirmed", "Name", "Price", "StockAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1230), "ürün açıklama", true, true, "Yelek 1", 619m, (byte)10, 12 },
                    { 2, 1, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1240), "ürün açıklama", false, true, "Yelek 2", 619m, (byte)10, 12 },
                    { 3, 1, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1250), "ürün açıklama", true, true, "Yelek 3", 510m, (byte)10, 12 },
                    { 4, 2, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1250), "ürün açıklama", true, true, "Triko 1", 700m, (byte)10, 13 },
                    { 5, 2, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1250), "ürün açıklama", false, true, "Triko 2", 700m, (byte)10, 13 },
                    { 6, 2, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1260), "ürün açıklama", false, true, "Triko 3", 700m, (byte)10, 13 },
                    { 7, 3, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1260), "ürün açıklama", true, true, "Sweatshirt 1", 320m, (byte)10, 12 },
                    { 8, 3, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1260), "ürün açıklama", false, true, "Sweatshirt 2", 450m, (byte)10, 12 },
                    { 9, 3, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1270), "ürün açıklama", true, true, "Sweatshirt 3", 600m, (byte)10, 12 },
                    { 10, 4, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1290), "ürün açıklama", true, true, "Şort 1", 900m, (byte)10, 13 },
                    { 11, 4, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1290), "ürün açıklama", true, true, "Şort 2", 900m, (byte)10, 13 },
                    { 12, 4, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1290), "ürün açıklama", false, true, "Şort 3", 900m, (byte)10, 13 },
                    { 13, 4, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1300), "ürün açıklama", false, false, "Şort 4", 900m, (byte)10, 13 },
                    { 14, 4, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1300), "ürün açıklama", false, true, "Şort 5", 900m, (byte)10, 13 },
                    { 15, 5, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1300), "ürün açıklama", true, true, "Kazak 1", 300m, (byte)10, 12 },
                    { 16, 5, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1310), "ürün açıklama", true, true, "Kazak 2", 300m, (byte)10, 12 },
                    { 17, 5, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1310), "ürün açıklama", false, false, "Kazak 3", 300m, (byte)10, 12 },
                    { 18, 6, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1320), "ürün açıklama", true, false, "Elbise 1", 500m, (byte)10, 12 },
                    { 19, 6, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1320), "ürün açıklama", true, true, "Elbise 2", 500m, (byte)10, 12 },
                    { 20, 6, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1320), "ürün açıklama", false, true, "Elbise 3", 500m, (byte)10, 12 },
                    { 21, 6, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1330), "ürün açıklama", false, true, "Elbise 4", 500m, (byte)10, 12 },
                    { 22, 7, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1330), "ürün açıklama", true, true, "Ceket 1", 360m, (byte)10, 13 },
                    { 23, 7, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1330), "ürün açıklama", true, false, "Ceket 2", 360m, (byte)10, 13 },
                    { 24, 7, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1340), "ürün açıklama", false, true, "Ceket 3", 360m, (byte)10, 13 },
                    { 25, 7, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1340), "ürün açıklama", false, true, "Ceket 4", 360m, (byte)10, 13 },
                    { 26, 8, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1340), "ürün açıklama", true, true, "Pantolon 1", 400m, (byte)10, 12 },
                    { 27, 8, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1350), "ürün açıklama", false, true, "Pantolon 2", 400m, (byte)10, 12 },
                    { 28, 8, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1350), "ürün açıklama", true, false, "Pantolon 3", 400m, (byte)10, 12 },
                    { 29, 8, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1350), "ürün açıklama", false, true, "Pantolon 4", 400m, (byte)10, 12 },
                    { 30, 9, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1360), "ürün açıklama", true, true, "Etek 1", 550m, (byte)10, 13 },
                    { 31, 9, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1360), "ürün açıklama", true, true, "Etek 2", 550m, (byte)10, 13 },
                    { 32, 9, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1360), "ürün açıklama", true, false, "Etek 3", 550m, (byte)10, 13 },
                    { 33, 9, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1360), "ürün açıklama", true, true, "Etek 4", 550m, (byte)10, 13 },
                    { 34, 10, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1370), "ürün açıklama", false, true, "Bluz 1", 450m, (byte)10, 12 },
                    { 35, 10, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1370), "ürün açıklama", true, false, "Bluz 2", 450m, (byte)10, 12 },
                    { 36, 10, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1380), "ürün açıklama", true, true, "Bluz 3", 450m, (byte)10, 12 },
                    { 37, 10, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1380), "ürün açıklama", true, true, "Bluz 4", 450m, (byte)10, 12 },
                    { 38, 10, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1380), "ürün açıklama", false, true, "Bluz 5", 450m, (byte)10, 12 }
                });

            migrationBuilder.InsertData(
                table: "ProductComments",
                columns: new[] { "Id", "CreatedAt", "IsConfirmed", "ProductId", "StarCount", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1430), true, 1, (byte)5, "Great product!", 1 },
                    { 2, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1440), true, 2, (byte)5, "Great product!", 2 },
                    { 3, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1440), true, 3, (byte)3, "Great product!", 3 },
                    { 4, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1440), true, 4, (byte)5, "Great product!", 4 },
                    { 5, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1440), true, 5, (byte)5, "Great product!", 5 },
                    { 6, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1450), true, 6, (byte)1, "Great product!", 6 },
                    { 7, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1450), true, 7, (byte)5, "Great product!", 7 },
                    { 8, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1450), true, 8, (byte)5, "Great product!", 8 },
                    { 9, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1450), true, 9, (byte)5, "Great product!", 9 },
                    { 10, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1450), true, 10, (byte)4, "Great product!", 10 },
                    { 11, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1460), true, 11, (byte)5, "Great product!", 1 },
                    { 12, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1460), true, 12, (byte)5, "Great product!", 2 },
                    { 13, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1460), true, 13, (byte)5, "Great product!", 3 },
                    { 14, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1460), true, 14, (byte)5, "Great product!", 4 },
                    { 15, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1470), true, 15, (byte)4, "Nice product!", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1550), 1, "yelek-01.jpg", 12 },
                    { 2, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1560), 2, "yelek-02.jpg", 12 },
                    { 3, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1560), 3, "yelek-03.jpg", 12 },
                    { 4, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1570), 4, "triko-01.jpg", 13 },
                    { 5, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1580), 5, "triko-02.jpg", 13 },
                    { 6, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1580), 6, "triko-03.jpg", 13 },
                    { 7, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1590), 7, "sweatshirt-01.jpg", 12 },
                    { 8, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1590), 8, "sweatshirt-02.jpg", 12 },
                    { 9, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1600), 9, "sweatshirt-03.jpg", 12 },
                    { 10, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1600), 10, "sort-01.jpg", 13 },
                    { 11, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1610), 11, "sort-02.jpg", 13 },
                    { 12, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1610), 12, "sort-03.jpg", 13 },
                    { 13, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1620), 13, "sort-04.jpg", 13 },
                    { 14, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1620), 14, "sort-05.jpg", 13 },
                    { 15, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1630), 15, "kazak-01.jpg", 12 },
                    { 16, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1640), 16, "kazak-02.jpg", 12 },
                    { 17, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1640), 17, "kazak-03.jpg", 12 },
                    { 18, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1650), 18, "elbise-01.jpg", 12 },
                    { 19, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1650), 19, "elbise-02.jpg", 12 },
                    { 20, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1660), 20, "elbise-03.jpg", 12 },
                    { 21, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1660), 21, "elbise-04.jpg", 12 },
                    { 22, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1670), 22, "ceket-01.jpg", 13 },
                    { 23, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1670), 23, "ceket-02.jpg", 13 },
                    { 24, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1680), 24, "ceket-03.jpg", 13 },
                    { 25, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1690), 25, "ceket-04.jpg", 13 },
                    { 26, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1690), 26, "pantolon-01.jpg", 12 },
                    { 27, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1700), 27, "pantolon-02.jpg", 12 },
                    { 28, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1700), 28, "pantolon-03.jpg", 12 },
                    { 29, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1710), 29, "pantolon-01.jpg", 12 },
                    { 30, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1710), 30, "etek-01.jpg", 13 },
                    { 31, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1720), 31, "etek-02.jpg", 13 },
                    { 32, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1720), 32, "etek-03.jpg", 13 },
                    { 33, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1740), 33, "etek-04.jpg", 13 },
                    { 34, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1750), 34, "bluz-01.jpg", 12 },
                    { 35, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1760), 35, "bluz-02.jpg", 12 },
                    { 36, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1760), 36, "bluz-03.jpg", 12 },
                    { 37, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1770), 37, "bluz-04.jpg", 12 },
                    { 38, new DateTime(2024, 8, 15, 15, 56, 13, 686, DateTimeKind.Local).AddTicks(1770), 38, "bluz-05.jpg", 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_UserId",
                table: "OrderItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_ProductId",
                table: "ProductComments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_UserId",
                table: "ProductComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_UserId",
                table: "ProductImages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductComments");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");
        }
    }
}