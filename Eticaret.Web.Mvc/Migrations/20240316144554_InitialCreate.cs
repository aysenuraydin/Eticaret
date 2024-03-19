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
                    { 1, "pink", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9790), null, "dress" },
                    { 2, "red", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9790), null, "jean" },
                    { 3, "blue", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9790), null, "Sweatshirt" },
                    { 4, "yellow", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9790), null, "Sweatpants" },
                    { 5, "black", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9790), null, "Jumper" },
                    { 6, "white", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9800), null, "Cardigan" },
                    { 7, "gray", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9800), null, "Outerwear" },
                    { 8, "darkred", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9800), null, "Trousers" },
                    { 9, "blue", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9800), null, "Shirt" },
                    { 10, "white", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9800), null, "T-shirt" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9600), "seller" },
                    { 2, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9630), "buyer" },
                    { 3, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9630), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Discriminator", "Email", "Enabled", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9670), "User", "aysenur@aydin.com", true, "Admin", "Admin", "123456", 3 },
                    { 2, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9680), "User", "ays2@ayd.com", true, "Ayşenur4", "Aydın4", "123456", 2 },
                    { 3, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9680), "User", "ays3@ayd.com", true, "Ayşenur5", "Aydın5", "123456", 2 },
                    { 4, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9680), "User", "ays4@ayd.com", true, "Ayşenur6", "Aydın6", "123456", 2 },
                    { 5, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9690), "User", "ays5@ayd.com", true, "Ayşenur7", "Aydın7", "123456", 2 },
                    { 6, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9690), "User", "ays6@ayd.com", true, "Ayşenur4", "Aydın4", "123456", 2 },
                    { 7, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9690), "User", "ays7@ayd.com", true, "Ayşenur5", "Aydın5", "123456", 2 },
                    { 8, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9690), "User", "ays8@ayd.com", true, "Ayşenur6", "Aydın6", "123456", 2 },
                    { 9, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9700), "User", "ays9@ayd.com", true, "Ayşenur7", "Aydın7", "123456", 2 },
                    { 10, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9700), "User", "ays10@ayd.com", true, "Ayşenur2", "Aydın2", "123456", 2 },
                    { 11, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9720), "Seller", "ays11@ayd.com", true, "Ayşenur5", "Aydın5", "123456", 1 },
                    { 12, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9730), "Seller", "ays12@ayd.com", true, "Ayşenur6", "Aydın6", "123456", 1 },
                    { 13, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9730), "Seller", "ays13@ayd.com", true, "Ayşenur7", "Aydın7", "123456", 1 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Address", "CreatedAt", "OrderCode", "UserId" },
                values: new object[,]
                {
                    { 1, "456 Elm St", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9970), "ORD001", 9 },
                    { 2, "789 Oak St", new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9970), "ORD002", 10 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Details", "Enabled", "IsConfirmed", "Name", "Price", "SellerId", "StockAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9820), "ürün açıklama", true, true, "Product 1", 10m, 11, (byte)10 },
                    { 2, 2, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9830), "ürün açıklama", false, true, "Product 2", 10m, 11, (byte)10 },
                    { 3, 3, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9830), "ürün açıklama", true, true, "Product 3", 10m, 11, (byte)10 },
                    { 4, 4, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9840), "ürün açıklama", true, true, "Product 4", 10m, 11, (byte)10 },
                    { 5, 5, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9840), "ürün açıklama", false, true, "Product 5", 10m, 11, (byte)10 },
                    { 6, 6, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9840), "ürün açıklama", true, true, "Product 6", 10m, 11, (byte)10 },
                    { 7, 7, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9840), "ürün açıklama", true, true, "Product 7", 10m, 11, (byte)10 },
                    { 8, 8, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9850), "ürün açıklama", false, true, "Product 8", 10m, 11, (byte)10 },
                    { 9, 9, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9850), "ürün açıklama", false, true, "Product 9", 10m, 12, (byte)10 },
                    { 10, 10, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9850), "ürün açıklama", true, true, "Product 10", 10m, 12, (byte)10 },
                    { 11, 2, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9850), "ürün açıklama", true, true, "Product 11", 10m, 12, (byte)10 },
                    { 12, 4, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9860), "ürün açıklama", false, true, "Product 12", 10m, 12, (byte)10 },
                    { 13, 6, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9860), "ürün açıklama", true, true, "Product 13", 10m, 12, (byte)10 },
                    { 14, 8, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9860), "ürün açıklama", true, true, "Product 14", 10m, 12, (byte)10 },
                    { 15, 10, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9860), "ürün açıklama", false, true, "Product 15", 10m, 13, (byte)10 },
                    { 16, 4, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9870), "ürün açıklama", false, true, "Product 16", 10m, 13, (byte)10 },
                    { 17, 6, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9870), "ürün açıklama", true, true, "Product 17", 10m, 13, (byte)10 },
                    { 18, 8, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9870), "ürün açıklama", true, true, "Product 18", 10m, 12, (byte)10 },
                    { 19, 10, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9870), "ürün açıklama", false, true, "Product 19", 10m, 12, (byte)10 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 16, 17, 45, 54, 97, DateTimeKind.Local), 1, (byte)1, 1 },
                    { 2, new DateTime(2024, 3, 16, 17, 45, 54, 97, DateTimeKind.Local), 2, (byte)3, 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "CreatedAt", "OrderId", "ProductId", "Quantity", "SellerId", "UnitPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9980), 1, 1, (byte)2, 11, 10.99m },
                    { 2, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9990), 2, 2, (byte)1, 12, 19.99m }
                });

            migrationBuilder.InsertData(
                table: "ProductComments",
                columns: new[] { "Id", "CreatedAt", "IsConfirmed", "ProductId", "StarCount", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9910), true, 1, (byte)5, "Great product!", 1 },
                    { 2, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9920), true, 2, (byte)5, "Great product!", 2 },
                    { 3, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9920), true, 3, (byte)3, "Great product!", 3 },
                    { 4, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9920), true, 4, (byte)5, "Great product!", 4 },
                    { 5, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9920), true, 5, (byte)5, "Great product!", 5 },
                    { 6, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9930), true, 6, (byte)1, "Great product!", 6 },
                    { 7, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9930), true, 7, (byte)5, "Great product!", 7 },
                    { 8, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9930), true, 8, (byte)5, "Great product!", 8 },
                    { 9, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9930), true, 9, (byte)5, "Great product!", 9 },
                    { 10, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9930), true, 10, (byte)4, "Great product!", 10 },
                    { 11, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9930), true, 11, (byte)5, "Great product!", 1 },
                    { 12, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9940), true, 12, (byte)5, "Great product!", 2 },
                    { 13, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9940), true, 13, (byte)5, "Great product!", 3 },
                    { 14, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9940), true, 14, (byte)5, "Great product!", 4 },
                    { 15, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9940), true, 15, (byte)4, "Nice product!", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "ProductId", "SellerId", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9900), 1, 11, "https://example.com/image1.jpg" },
                    { 2, new DateTime(2024, 3, 16, 17, 45, 54, 96, DateTimeKind.Local).AddTicks(9900), 2, 11, "https://example.com/image2.jpg" }
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
