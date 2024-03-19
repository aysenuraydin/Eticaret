using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eticaret.Web.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7250));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7250), 3, (byte)1 });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7250), 2, (byte)3, 3 },
                    { 4, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7260), 4, (byte)1, 4 },
                    { 5, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7260), 5, (byte)1, 5 },
                    { 6, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7260), 6, (byte)3, 6 },
                    { 7, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7260), 7, (byte)1, 7 },
                    { 8, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7260), 8, (byte)1, 8 },
                    { 9, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7260), 9, (byte)3, 9 },
                    { 10, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7260), 3, (byte)1, 10 },
                    { 11, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7260), 7, (byte)1, 7 },
                    { 12, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7270), 8, (byte)3, 2 },
                    { 13, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7270), 2, (byte)1, 1 },
                    { 14, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7270), 1, (byte)1, 3 },
                    { 15, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7270), 3, (byte)3, 4 },
                    { 16, new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7270), 2, (byte)3, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7240));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7220));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7200));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7160));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7100));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(7120));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6940));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 47, 8, 941, DateTimeKind.Local).AddTicks(6990));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8180));

            migrationBuilder.UpdateData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ProductId", "Quantity" },
                values: new object[] { new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8180), 2, (byte)3 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8170));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8110));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8120));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8070));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8010));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7780));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7850));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 17, 22, 41, 41, 536, DateTimeKind.Local).AddTicks(7880));
        }
    }
}
