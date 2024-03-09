using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Persistence.Ef.SeedDatas
{
    public static class TestDataSeeder
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new List<Category>() {
                new() { Id=1, Name="dress", Color="pink", IconCssClass=""},
                new() { Id=2, Name="jean", Color="red", IconCssClass=""},
                new() { Id=3, Name="Sweatshirt", Color="blue", IconCssClass=""},
                new() { Id=4, Name="Sweatpants", Color="yellow", IconCssClass=""},
                new() { Id=5, Name="Jumper", Color="black", IconCssClass=""},
                new() { Id=6, Name="Cardigan", Color="white", IconCssClass=""},
                new() { Id=7, Name="Outerwear", Color="gray", IconCssClass=""},
                new() { Id=8, Name="Trousers", Color="darkred", IconCssClass=""},
                new() { Id=9, Name="Shirt", Color="blue", IconCssClass=""},
                new() { Id=10, Name="T-shirt", Color="white", IconCssClass=""}
                }
            );
            modelBuilder.Entity<Role>().HasData(
              new List<Role>() {
                 new() { Id=1, Name="seller"},
                 new() { Id=2, Name="buyer"},
                 new() { Id=3, Name="admin"}
              }
            );

            modelBuilder.Entity<Product>().HasData(
              new List<Product>() {
                 new() { Id=1, Name="Product 1", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=1},
                 new() { Id=2, Name="Product 2", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=2, CategoryId=2},
                 new() { Id=3, Name="Product 3", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=3},
                 new() { Id=4, Name="Product 4", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=2, CategoryId=4},
                 new() { Id=5, Name="Product 5", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=5},
                 new() { Id=6, Name="Product 6", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=6},
                 new() { Id=7, Name="Product 7", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=2, CategoryId=7},
                 new() { Id=8, Name="Product 8", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=8},
                 new() { Id=9, Name="Product 9", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=2, CategoryId=9},
                 new() { Id=10, Name="Product 10", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=10},
                 new() { Id=11, Name="Product 11", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=2},
                 new() { Id=12, Name="Product 12", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=2, CategoryId=4},
                 new() { Id=13, Name="Product 13", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=2, CategoryId=6},
                 new() { Id=14, Name="Product 14", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=8},
                 new() { Id=15, Name="Product 15", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=1, CategoryId=10}
              }
            );

            modelBuilder.Entity<User>().HasData(
             new List<User>() {
                  new() { Id=1, Email="ays@ayd.com",FirstName="Admin", Password="123456", Enabled=true, RoleId=3},
                  new() { Id=2, Email="ays@ayd.com",FirstName="Ayşenur4", LastName="Aydın4", Password="123456", Enabled=true, RoleId=2},
                  new() { Id=3, Email="ays@ayd.com",FirstName="Ayşenur5", LastName="Aydın5", Password="123456", Enabled=true, RoleId=2},
                  new() { Id=4, Email="ays@ayd.com",FirstName="Ayşenur6", LastName="Aydın6", Password="123456", Enabled=true, RoleId=2},
                  new() { Id=5, Email="ays@ayd.com",FirstName="Ayşenur7", LastName="Aydın7", Password="123456", Enabled=true, RoleId=2},
                  new() { Id=6, Email="ays@ayd.com",FirstName="Ayşenur2", LastName="Aydın2", Password="123456", Enabled=true, RoleId=2}
             }
         );
            modelBuilder.Entity<Seller>().HasData(
               new List<Seller>() {
                 new() { Id=7, Email="ays@ayd.com",FirstName="Ayşenur1", LastName="Aydın1", Password="123456", Enabled=true, RoleId=1,Adress="Bursa", CallNumber=5552552525},
                 new() { Id=8, Email="ays@ayd.com",FirstName="Ayşenur3", LastName="Aydın3", Password="123456", Enabled=true, RoleId=1,Adress="Bursa", CallNumber=5552552525}
               }
             );
        }
    }
}
