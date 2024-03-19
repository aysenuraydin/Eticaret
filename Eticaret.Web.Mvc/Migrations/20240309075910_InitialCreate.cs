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
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "TEXT", maxLength: 6, nullable: true),
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
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
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    Adress = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    CallNumber = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id");
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
                    OrderCode = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
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
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    StockAmount = table.Column<byte>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Enabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    SellerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
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
                    CartId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id");
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
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "ProductComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    StarCount = table.Column<byte>(type: "INTEGER", maxLength: 5, nullable: false),
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
                    Url = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    SellerId = table.Column<int>(type: "INTEGER", nullable: true)
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
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "IconCssClass", "Name" },
                values: new object[,]
                {
                    { 1, "pink", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2420), "", "dress" },
                    { 2, "red", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2450), "", "jean" },
                    { 3, "blue", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2460), "", "Sweatshirt" },
                    { 4, "yellow", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2460), "", "Sweatpants" },
                    { 5, "black", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2490), "", "Jumper" },
                    { 6, "white", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2490), "", "Cardigan" },
                    { 7, "gray", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2500), "", "Outerwear" },
                    { 8, "darkred", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2500), "", "Trousers" },
                    { 9, "blue", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2500), "", "Shirt" },
                    { 10, "white", new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2500), "", "T-shirt" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2550), "seller" },
                    { 2, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2550), "buyer" },
                    { 3, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2550), "admin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CartId", "CreatedAt", "Discriminator", "Email", "Enabled", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2630), "User", "ays@ayd.com", true, "Admin", null, "123456", 3 },
                    { 2, null, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2630), "User", "ays@ayd.com", true, "Ayşenur4", "Aydın4", "123456", 2 },
                    { 3, null, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2630), "User", "ays@ayd.com", true, "Ayşenur5", "Aydın5", "123456", 2 },
                    { 4, null, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2640), "User", "ays@ayd.com", true, "Ayşenur6", "Aydın6", "123456", 2 },
                    { 5, null, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2640), "User", "ays@ayd.com", true, "Ayşenur7", "Aydın7", "123456", 2 },
                    { 6, null, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2640), "User", "ays@ayd.com", true, "Ayşenur2", "Aydın2", "123456", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "CallNumber", "CartId", "CreatedAt", "Discriminator", "Email", "Enabled", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 7, "Bursa", 5552552525L, null, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2660), "Seller", "ays@ayd.com", true, "Ayşenur1", "Aydın1", "123456", 1 },
                    { 8, "Bursa", 5552552525L, null, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2660), "Seller", "ays@ayd.com", true, "Ayşenur3", "Aydın3", "123456", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Details", "Enabled", "Name", "Price", "SellerId", "StockAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2570), "ürün açıklama", true, "Product 1", 10m, 1, (byte)10 },
                    { 2, 2, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2580), "ürün açıklama", true, "Product 2", 10m, 2, (byte)10 },
                    { 3, 3, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2580), "ürün açıklama", true, "Product 3", 10m, 1, (byte)10 },
                    { 4, 4, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2580), "ürün açıklama", true, "Product 4", 10m, 2, (byte)10 },
                    { 5, 5, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2580), "ürün açıklama", true, "Product 5", 10m, 1, (byte)10 },
                    { 6, 6, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2590), "ürün açıklama", true, "Product 6", 10m, 1, (byte)10 },
                    { 7, 7, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2590), "ürün açıklama", true, "Product 7", 10m, 2, (byte)10 },
                    { 8, 8, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2590), "ürün açıklama", true, "Product 8", 10m, 1, (byte)10 },
                    { 9, 9, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2590), "ürün açıklama", true, "Product 9", 10m, 2, (byte)10 },
                    { 10, 10, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2600), "ürün açıklama", true, "Product 10", 10m, 1, (byte)10 },
                    { 11, 2, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2600), "ürün açıklama", true, "Product 11", 10m, 1, (byte)10 },
                    { 12, 4, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2600), "ürün açıklama", true, "Product 12", 10m, 2, (byte)10 },
                    { 13, 6, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2600), "ürün açıklama", true, "Product 13", 10m, 2, (byte)10 },
                    { 14, 8, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2600), "ürün açıklama", true, "Product 14", 10m, 1, (byte)10 },
                    { 15, 10, new DateTime(2024, 3, 9, 10, 59, 10, 691, DateTimeKind.Local).AddTicks(2610), "ürün açıklama", true, "Product 15", 10m, 1, (byte)10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

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
                name: "IX_Users_CartId",
                table: "Users",
                column: "CartId");

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
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
