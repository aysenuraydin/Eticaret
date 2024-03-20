using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eticaret.Web.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
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
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    SellerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
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
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    SellerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
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
                    table.ForeignKey(
                        name: "FK_OrderItems_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
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
                        name: "FK_ProductComments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    SellerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductImages_Users_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "IconCssClass", "Name" },
                values: new object[,]
                {
                    { 1, "pink", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1360), null, "Yelek" },
                    { 2, "red", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1360), null, "Triko" },
                    { 3, "blue", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1360), null, "Sweatshirt" },
                    { 4, "yellow", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1360), null, "Şort" },
                    { 5, "black", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1360), null, "Kazak" },
                    { 6, "white", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1360), null, "Elbise" },
                    { 7, "gray", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1370), null, "Ceket" },
                    { 8, "darkred", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1370), null, "Pantolon" },
                    { 9, "blue", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1370), null, "Etek" },
                    { 10, "white", new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1390), null, "Bluz" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1160), "seller" },
                    { 2, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1190), "buyer" },
                    { 3, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1190), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Discriminator", "Email", "Enabled", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1230), "User", "aysenur@aydin.com", true, "Admin", "Admin", "123456", 3 },
                    { 2, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1230), "User", "ays2@ayd.com", true, "Ayşenur4", "Aydın4", "123456", 2 },
                    { 3, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1230), "User", "ays3@ayd.com", true, "Ayşenur5", "Aydın5", "123456", 2 },
                    { 4, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1240), "User", "ays4@ayd.com", true, "Ayşenur6", "Aydın6", "123456", 2 },
                    { 5, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1240), "User", "ays5@ayd.com", true, "Ayşenur7", "Aydın7", "123456", 2 },
                    { 6, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1240), "User", "ays6@ayd.com", true, "Ayşenur4", "Aydın4", "123456", 2 },
                    { 7, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1240), "User", "ays7@ayd.com", true, "Ayşenur5", "Aydın5", "123456", 2 },
                    { 8, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1250), "User", "ays8@ayd.com", true, "Ayşenur6", "Aydın6", "123456", 2 },
                    { 9, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1250), "User", "ays9@ayd.com", true, "Ayşenur7", "Aydın7", "123456", 2 },
                    { 10, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1250), "User", "ays10@ayd.com", true, "Ayşenur2", "Aydın2", "123456", 2 },
                    { 11, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1270), "Seller", "ays11@ayd.com", true, "Ayşenur5", "Aydın5", "123456", 1 },
                    { 12, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1280), "Seller", "ays12@ayd.com", true, "Ayşenur6", "Aydın6", "123456", 1 },
                    { 13, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1280), "Seller", "ays13@ayd.com", true, "Ayşenur7", "Aydın7", "123456", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Details", "Enabled", "IsConfirmed", "Name", "Price", "SellerId", "StockAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1400), "ürün açıklama", true, true, "Yelek 1", 619m, 12, (byte)10 },
                    { 2, 1, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1410), "ürün açıklama", false, true, "Yelek 2", 619m, 12, (byte)10 },
                    { 3, 1, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1410), "ürün açıklama", true, true, "Yelek 3", 510m, 12, (byte)10 },
                    { 4, 2, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1420), "ürün açıklama", true, true, "Triko 1", 700m, 13, (byte)10 },
                    { 5, 2, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1420), "ürün açıklama", false, true, "Triko 2", 700m, 13, (byte)10 },
                    { 6, 2, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1420), "ürün açıklama", false, true, "Triko 3", 700m, 13, (byte)10 },
                    { 7, 3, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1420), "ürün açıklama", true, true, "Sweatshirt 1", 320m, 12, (byte)10 },
                    { 8, 3, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1430), "ürün açıklama", false, true, "Sweatshirt 2", 450m, 12, (byte)10 },
                    { 9, 3, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1430), "ürün açıklama", true, true, "Sweatshirt 3", 600m, 12, (byte)10 },
                    { 10, 4, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1430), "ürün açıklama", true, true, "Şort 1", 900m, 13, (byte)10 },
                    { 11, 4, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1430), "ürün açıklama", true, true, "Şort 2", 900m, 13, (byte)10 },
                    { 12, 4, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1440), "ürün açıklama", false, true, "Şort 3", 900m, 13, (byte)10 },
                    { 13, 4, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1440), "ürün açıklama", false, false, "Şort 4", 900m, 13, (byte)10 },
                    { 14, 4, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1440), "ürün açıklama", false, true, "Şort 5", 900m, 13, (byte)10 },
                    { 15, 5, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1440), "ürün açıklama", true, true, "Kazak 1", 300m, 12, (byte)10 },
                    { 16, 5, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1450), "ürün açıklama", true, true, "Kazak 2", 300m, 12, (byte)10 },
                    { 17, 5, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1450), "ürün açıklama", false, false, "Kazak 3", 300m, 12, (byte)10 },
                    { 18, 6, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1450), "ürün açıklama", true, false, "Elbise 1", 500m, 12, (byte)10 },
                    { 19, 6, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1450), "ürün açıklama", true, true, "Elbise 2", 500m, 12, (byte)10 },
                    { 20, 6, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1460), "ürün açıklama", false, true, "Elbise 3", 500m, 12, (byte)10 },
                    { 21, 6, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1460), "ürün açıklama", false, true, "Elbise 4", 500m, 12, (byte)10 },
                    { 22, 7, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1460), "ürün açıklama", true, true, "Ceket 1", 360m, 13, (byte)10 },
                    { 23, 7, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1460), "ürün açıklama", true, false, "Ceket 2", 360m, 13, (byte)10 },
                    { 24, 7, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1470), "ürün açıklama", false, true, "Ceket 3", 360m, 13, (byte)10 },
                    { 25, 7, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1470), "ürün açıklama", false, true, "Ceket 4", 360m, 13, (byte)10 },
                    { 26, 8, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1470), "ürün açıklama", true, true, "Pantolon 1", 400m, 12, (byte)10 },
                    { 27, 8, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1470), "ürün açıklama", false, true, "Pantolon 2", 400m, 12, (byte)10 },
                    { 28, 8, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1470), "ürün açıklama", true, false, "Pantolon 3", 400m, 12, (byte)10 },
                    { 29, 8, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1480), "ürün açıklama", false, true, "Pantolon 4", 400m, 12, (byte)10 },
                    { 30, 9, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1480), "ürün açıklama", true, true, "Etek 1", 5550m, 13, (byte)10 },
                    { 31, 9, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1480), "ürün açıklama", true, true, "Etek 2", 5550m, 13, (byte)10 },
                    { 32, 9, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1490), "ürün açıklama", true, false, "Etek 3", 5550m, 13, (byte)10 },
                    { 33, 9, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1490), "ürün açıklama", true, true, "Etek 4", 5550m, 13, (byte)10 },
                    { 34, 10, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1490), "ürün açıklama", false, true, "Bluz 1", 450m, 12, (byte)10 },
                    { 35, 10, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1490), "ürün açıklama", true, false, "Bluz 2", 450m, 12, (byte)10 },
                    { 36, 10, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1500), "ürün açıklama", true, true, "Bluz 3", 450m, 12, (byte)10 },
                    { 37, 10, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1500), "ürün açıklama", true, true, "Bluz 4", 450m, 12, (byte)10 },
                    { 38, 10, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1500), "ürün açıklama", false, true, "Bluz 5", 450m, 12, (byte)10 }
                });

            migrationBuilder.InsertData(
                table: "ProductComments",
                columns: new[] { "Id", "CreatedAt", "IsConfirmed", "ProductId", "StarCount", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1530), true, 1, (byte)5, "Great product!", 1 },
                    { 2, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1540), true, 2, (byte)5, "Great product!", 2 },
                    { 3, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1540), true, 3, (byte)3, "Great product!", 3 },
                    { 4, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1540), true, 4, (byte)5, "Great product!", 4 },
                    { 5, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1540), true, 5, (byte)5, "Great product!", 5 },
                    { 6, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1540), true, 6, (byte)1, "Great product!", 6 },
                    { 7, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1550), true, 7, (byte)5, "Great product!", 7 },
                    { 8, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1550), true, 8, (byte)5, "Great product!", 8 },
                    { 9, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1550), true, 9, (byte)5, "Great product!", 9 },
                    { 10, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1550), true, 10, (byte)4, "Great product!", 10 },
                    { 11, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1550), true, 11, (byte)5, "Great product!", 1 },
                    { 12, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1550), true, 12, (byte)5, "Great product!", 2 },
                    { 13, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1550), true, 13, (byte)5, "Great product!", 3 },
                    { 14, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1560), true, 14, (byte)5, "Great product!", 4 },
                    { 15, new DateTime(2024, 3, 20, 23, 19, 12, 208, DateTimeKind.Local).AddTicks(1560), true, 15, (byte)4, "Nice product!", 2 }
                });

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
                name: "IX_OrderItems_SellerId",
                table: "OrderItems",
                column: "SellerId");

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
                name: "IX_ProductImages_SellerId",
                table: "ProductImages",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
