using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Eticaret.Web.Mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate61 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CreatedAt", "ProductId", "Quantity", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4260), 1, (byte)1, 1 },
                    { 2, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4270), 3, (byte)1, 2 },
                    { 3, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4270), 2, (byte)3, 3 },
                    { 4, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4270), 4, (byte)1, 4 },
                    { 5, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4270), 5, (byte)1, 5 },
                    { 6, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4270), 6, (byte)3, 6 },
                    { 7, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4280), 7, (byte)1, 7 },
                    { 8, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4280), 8, (byte)1, 8 },
                    { 9, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4280), 9, (byte)3, 9 },
                    { 10, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4280), 3, (byte)1, 10 },
                    { 11, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4280), 4, (byte)1, 7 },
                    { 12, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4280), 8, (byte)3, 2 },
                    { 13, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4280), 2, (byte)1, 1 },
                    { 14, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4290), 1, (byte)1, 3 },
                    { 15, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4290), 3, (byte)3, 4 },
                    { 16, new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4290), 2, (byte)3, 7 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3950));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3970));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4240));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4220));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4230));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4120));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4140));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4100));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4110));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4030));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 19, 11, 21, 41, 518, DateTimeKind.Local).AddTicks(3890));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6760));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6920));

            migrationBuilder.UpdateData(
                table: "ProductComments",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6880));

            migrationBuilder.UpdateData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6890));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6810));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6820));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6830));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6550));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6650));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedAt",
                value: new DateTime(2024, 3, 18, 7, 25, 3, 827, DateTimeKind.Local).AddTicks(6700));
        }
    }
}
