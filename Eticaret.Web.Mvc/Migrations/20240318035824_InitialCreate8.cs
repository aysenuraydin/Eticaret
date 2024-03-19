using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eticaret.Web.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2);

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
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7910));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8040));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7960));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7980));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7990));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7750));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7760));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7810));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 58, 23, 935, DateTimeKind.Local).AddTicks(7860));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3470), 1, (byte)1, 1 },
                    { 2, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3480), 3, (byte)1, 2 },
                    { 3, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3480), 2, (byte)3, 3 },
                    { 4, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3480), 4, (byte)1, 4 },
                    { 5, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3480), 5, (byte)1, 5 },
                    { 6, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3480), 6, (byte)3, 6 },
                    { 7, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3480), 7, (byte)1, 7 },
                    { 8, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3490), 8, (byte)1, 8 },
                    { 9, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3490), 9, (byte)3, 9 },
                    { 10, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3490), 3, (byte)1, 10 },
                    { 11, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3490), 4, (byte)1, 7 },
                    { 12, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3490), 8, (byte)3, 2 },
                    { 13, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3490), 2, (byte)1, 1 },
                    { 14, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3490), 1, (byte)1, 3 },
                    { 15, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3500), 3, (byte)3, 4 },
                    { 16, new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3500), 2, (byte)3, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3240));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3250));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3260));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3450));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3460));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3440));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3390));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3400));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3410));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3380));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3290));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3300));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3310));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3340));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3350));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3150));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 6, 54, 47, 401, DateTimeKind.Local).AddTicks(3190));
        }
    }
}
