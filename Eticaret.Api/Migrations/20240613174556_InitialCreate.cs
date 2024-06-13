using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eticaret.Api.Migrations
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
                    { 1, null, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9400), "seller", "SELLER" },
                    { 2, null, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9440), "buyer", "BUYER" },
                    { 3, null, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9440), "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Color", "CreatedAt", "IconCssClass", "Name" },
                values: new object[,]
                {
                    { 1, "	#a4b2b0", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9660), null, "Yelek" },
                    { 2, "	#896863	", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9670), null, "Triko" },
                    { 3, "#C27D42	", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9670), null, "Sweatshirt" },
                    { 4, "	#BF8882	", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9670), null, "Şort" },
                    { 5, "	#A4B2B0	", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9670), null, "Kazak" },
                    { 6, "#828DE5", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9670), null, "Elbise" },
                    { 7, "#595B56	", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9670), null, "Ceket" },
                    { 8, "	#CDC6C3	", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9680), null, "Pantolon" },
                    { 9, "#DEBDB0", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9680), null, "Etek" },
                    { 10, "	#BE969B	", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9690), null, "Bluz" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "Enabled", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "05cea1db-c237-442f-8300-65c3db66f945", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9490), "aysenur@aydin.com", false, true, "Admin", "Admin", false, null, null, null, "123456", null, false, 3, null, false, null },
                    { 2, 0, "2335d995-4395-42f6-bad5-3694e6897928", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9530), "ays2@ayd.com", false, true, "Ayşenur4", "Aydın4", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 3, 0, "43a7ff7f-c190-4708-ab59-87caf323be67", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9530), "ays3@ayd.com", false, true, "Ayşenur5", "Aydın5", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 4, 0, "9a3eba83-e07b-4385-bdc7-667e3a81826e", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9540), "ays4@ayd.com", false, true, "Ayşenur6", "Aydın6", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 5, 0, "6291805c-5f4f-4192-aa09-68da00a1c48e", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9540), "ays5@ayd.com", false, true, "Ayşenur7", "Aydın7", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 6, 0, "9e46f78c-105f-40db-89ed-9994c1b179bd", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9550), "ays6@ayd.com", false, true, "Ayşenur4", "Aydın4", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 7, 0, "51ad8b41-a5e4-4d63-8884-385ddf966a31", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9550), "ays7@ayd.com", false, true, "Ayşenur5", "Aydın5", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 8, 0, "557b683e-8083-452f-9405-81c160f09ed7", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9560), "ays8@ayd.com", false, true, "Ayşenur6", "Aydın6", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 9, 0, "535fe498-2fe5-48b0-a670-74cc06ecd2c5", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9610), "ays9@ayd.com", false, true, "Ayşenur7", "Aydın7", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 10, 0, "8fa8a6cc-8141-4238-a954-2e4533d12214", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9620), "ays10@ayd.com", false, true, "Ayşenur2", "Aydın2", false, null, null, null, "123456", null, false, 2, null, false, null },
                    { 11, 0, "9df225c4-0928-421c-bbe1-df23fcd0241d", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9620), "ays11@ayd.com", false, true, "Ayşenur5", "Aydın5", false, null, null, null, "123456", null, false, 1, null, false, null },
                    { 12, 0, "61e5ed8c-b7e7-468d-b065-63cfff601ee8", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9630), "ays12@ayd.com", false, true, "Ayşenur6", "Aydın6", false, null, null, null, "123456", null, false, 1, null, false, null },
                    { 13, 0, "0a142705-2bf0-4562-b6ca-01eab4e2946c", new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9630), "ays13@ayd.com", false, true, "Ayşenur7", "Aydın7", false, null, null, null, "123456", null, false, 1, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Details", "Enabled", "IsConfirmed", "Name", "Price", "StockAmount", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9710), "ürün açıklama", true, true, "Yelek 1", 619m, (byte)10, 12 },
                    { 2, 1, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9720), "ürün açıklama", false, true, "Yelek 2", 619m, (byte)10, 12 },
                    { 3, 1, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9720), "ürün açıklama", true, true, "Yelek 3", 510m, (byte)10, 12 },
                    { 4, 2, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9720), "ürün açıklama", true, true, "Triko 1", 700m, (byte)10, 13 },
                    { 5, 2, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9720), "ürün açıklama", false, true, "Triko 2", 700m, (byte)10, 13 },
                    { 6, 2, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9730), "ürün açıklama", false, true, "Triko 3", 700m, (byte)10, 13 },
                    { 7, 3, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9730), "ürün açıklama", true, true, "Sweatshirt 1", 320m, (byte)10, 12 },
                    { 8, 3, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9730), "ürün açıklama", false, true, "Sweatshirt 2", 450m, (byte)10, 12 },
                    { 9, 3, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9740), "ürün açıklama", true, true, "Sweatshirt 3", 600m, (byte)10, 12 },
                    { 10, 4, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9740), "ürün açıklama", true, true, "Şort 1", 900m, (byte)10, 13 },
                    { 11, 4, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9740), "ürün açıklama", true, true, "Şort 2", 900m, (byte)10, 13 },
                    { 12, 4, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9740), "ürün açıklama", false, true, "Şort 3", 900m, (byte)10, 13 },
                    { 13, 4, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9750), "ürün açıklama", false, false, "Şort 4", 900m, (byte)10, 13 },
                    { 14, 4, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9750), "ürün açıklama", false, true, "Şort 5", 900m, (byte)10, 13 },
                    { 15, 5, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9750), "ürün açıklama", true, true, "Kazak 1", 300m, (byte)10, 12 },
                    { 16, 5, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9750), "ürün açıklama", true, true, "Kazak 2", 300m, (byte)10, 12 },
                    { 17, 5, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9760), "ürün açıklama", false, false, "Kazak 3", 300m, (byte)10, 12 },
                    { 18, 6, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9760), "ürün açıklama", true, false, "Elbise 1", 500m, (byte)10, 12 },
                    { 19, 6, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9760), "ürün açıklama", true, true, "Elbise 2", 500m, (byte)10, 12 },
                    { 20, 6, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9760), "ürün açıklama", false, true, "Elbise 3", 500m, (byte)10, 12 },
                    { 21, 6, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9770), "ürün açıklama", false, true, "Elbise 4", 500m, (byte)10, 12 },
                    { 22, 7, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9770), "ürün açıklama", true, true, "Ceket 1", 360m, (byte)10, 13 },
                    { 23, 7, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9770), "ürün açıklama", true, false, "Ceket 2", 360m, (byte)10, 13 },
                    { 24, 7, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9770), "ürün açıklama", false, true, "Ceket 3", 360m, (byte)10, 13 },
                    { 25, 7, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9780), "ürün açıklama", false, true, "Ceket 4", 360m, (byte)10, 13 },
                    { 26, 8, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9780), "ürün açıklama", true, true, "Pantolon 1", 400m, (byte)10, 12 },
                    { 27, 8, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9780), "ürün açıklama", false, true, "Pantolon 2", 400m, (byte)10, 12 },
                    { 28, 8, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9790), "ürün açıklama", true, false, "Pantolon 3", 400m, (byte)10, 12 },
                    { 29, 8, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9790), "ürün açıklama", false, true, "Pantolon 4", 400m, (byte)10, 12 },
                    { 30, 9, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9790), "ürün açıklama", true, true, "Etek 1", 550m, (byte)10, 13 },
                    { 31, 9, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9790), "ürün açıklama", true, true, "Etek 2", 550m, (byte)10, 13 },
                    { 32, 9, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9790), "ürün açıklama", true, false, "Etek 3", 550m, (byte)10, 13 },
                    { 33, 9, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9800), "ürün açıklama", true, true, "Etek 4", 550m, (byte)10, 13 },
                    { 34, 10, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9800), "ürün açıklama", false, true, "Bluz 1", 450m, (byte)10, 12 },
                    { 35, 10, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9800), "ürün açıklama", true, false, "Bluz 2", 450m, (byte)10, 12 },
                    { 36, 10, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9800), "ürün açıklama", true, true, "Bluz 3", 450m, (byte)10, 12 },
                    { 37, 10, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9810), "ürün açıklama", true, true, "Bluz 4", 450m, (byte)10, 12 },
                    { 38, 10, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9810), "ürün açıklama", false, true, "Bluz 5", 450m, (byte)10, 12 }
                });

            migrationBuilder.InsertData(
                table: "ProductComments",
                columns: new[] { "Id", "CreatedAt", "IsConfirmed", "ProductId", "StarCount", "Text", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9850), true, 1, (byte)5, "Great product!", 1 },
                    { 2, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9860), true, 2, (byte)5, "Great product!", 2 },
                    { 3, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9860), true, 3, (byte)3, "Great product!", 3 },
                    { 4, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9860), true, 4, (byte)5, "Great product!", 4 },
                    { 5, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9860), true, 5, (byte)5, "Great product!", 5 },
                    { 6, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9860), true, 6, (byte)1, "Great product!", 6 },
                    { 7, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9870), true, 7, (byte)5, "Great product!", 7 },
                    { 8, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9870), true, 8, (byte)5, "Great product!", 8 },
                    { 9, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9870), true, 9, (byte)5, "Great product!", 9 },
                    { 10, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9870), true, 10, (byte)4, "Great product!", 10 },
                    { 11, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9870), true, 11, (byte)5, "Great product!", 1 },
                    { 12, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9870), true, 12, (byte)5, "Great product!", 2 },
                    { 13, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9880), true, 13, (byte)5, "Great product!", 3 },
                    { 14, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9880), true, 14, (byte)5, "Great product!", 4 },
                    { 15, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9880), true, 15, (byte)4, "Nice product!", 2 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9940), 1, "yelek-01.jpg", 12 },
                    { 2, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9950), 2, "yelek-02.jpg", 12 },
                    { 3, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9950), 3, "yelek-03.jpg", 12 },
                    { 4, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9960), 4, "triko-01.jpg", 13 },
                    { 5, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9960), 5, "triko-02.jpg", 13 },
                    { 6, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9970), 6, "triko-03.jpg", 13 },
                    { 7, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9970), 7, "sweatshirt-01.jpg", 12 },
                    { 8, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9970), 8, "sweatshirt-02.jpg", 12 },
                    { 9, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9980), 9, "sweatshirt-03.jpg", 12 },
                    { 10, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9980), 10, "sort-01.jpg", 13 },
                    { 11, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9990), 11, "sort-02.jpg", 13 },
                    { 12, new DateTime(2024, 6, 13, 20, 45, 56, 130, DateTimeKind.Local).AddTicks(9990), 12, "sort-03.jpg", 13 },
                    { 13, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local), 13, "sort-04.jpg", 13 },
                    { 14, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local), 14, "sort-05.jpg", 13 },
                    { 15, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local), 15, "kazak-01.jpg", 12 },
                    { 16, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(10), 16, "kazak-02.jpg", 12 },
                    { 17, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(10), 17, "kazak-03.jpg", 12 },
                    { 18, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(20), 18, "elbise-01.jpg", 12 },
                    { 19, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(20), 19, "elbise-02.jpg", 12 },
                    { 20, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(20), 20, "elbise-03.jpg", 12 },
                    { 21, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(30), 21, "elbise-04.jpg", 12 },
                    { 22, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(30), 22, "ceket-01.jpg", 13 },
                    { 23, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(30), 23, "ceket-02.jpg", 13 },
                    { 24, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(40), 24, "ceket-03.jpg", 13 },
                    { 25, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(40), 25, "ceket-04.jpg", 13 },
                    { 26, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(50), 26, "pantolon-01.jpg", 12 },
                    { 27, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(50), 27, "pantolon-02.jpg", 12 },
                    { 28, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(50), 28, "pantolon-03.jpg", 12 },
                    { 29, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(60), 29, "pantolon-01.jpg", 12 },
                    { 30, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(60), 30, "etek-01.jpg", 13 },
                    { 31, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(70), 31, "etek-02.jpg", 13 },
                    { 32, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(70), 32, "etek-03.jpg", 13 },
                    { 33, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(70), 33, "etek-04.jpg", 13 },
                    { 34, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(80), 34, "bluz-01.jpg", 12 },
                    { 35, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(80), 35, "bluz-02.jpg", 12 },
                    { 36, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(90), 36, "bluz-03.jpg", 12 },
                    { 37, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(90), 37, "bluz-04.jpg", 12 },
                    { 38, new DateTime(2024, 6, 13, 20, 45, 56, 131, DateTimeKind.Local).AddTicks(100), 38, "bluz-05.jpg", 12 }
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
