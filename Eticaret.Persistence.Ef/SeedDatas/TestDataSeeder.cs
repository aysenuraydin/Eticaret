using Eticaret.Domain;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Persistence.Ef.SeedDatas
{
  public static class TestDataSeeder
  {
    public static void SeedData(this ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Role>().HasData(
        new List<Role>() {
           new() { Id=1, Name="seller"},
           new() { Id=2, Name="buyer"},
           new() { Id=3, Name="admin"}
        }
      );
      modelBuilder.Entity<User>().HasData(
       new List<User>() {
         new() { Id=1, Email="aysenur@aydin.com",FirstName="Admin",LastName="Admin", Password="123456", Enabled=true, RoleId=3},
         new() { Id=2, Email="ays2@ayd.com",FirstName="Ayşenur4", LastName="Aydın4", Password="123456", Enabled=true, RoleId=2},
         new() { Id=3, Email="ays3@ayd.com",FirstName="Ayşenur5", LastName="Aydın5", Password="123456", Enabled=true, RoleId=2},
         new() { Id=4, Email="ays4@ayd.com",FirstName="Ayşenur6", LastName="Aydın6", Password="123456", Enabled=true, RoleId=2},
         new() { Id=5, Email="ays5@ayd.com",FirstName="Ayşenur7", LastName="Aydın7", Password="123456", Enabled=true, RoleId=2},
         new() { Id=6, Email="ays6@ayd.com",FirstName="Ayşenur4", LastName="Aydın4", Password="123456", Enabled=true, RoleId=2},
         new() { Id=7, Email="ays7@ayd.com",FirstName="Ayşenur5", LastName="Aydın5", Password="123456", Enabled=true, RoleId=2},
         new() { Id=8, Email="ays8@ayd.com",FirstName="Ayşenur6", LastName="Aydın6", Password="123456", Enabled=true, RoleId=2},
         new() { Id=9, Email="ays9@ayd.com",FirstName="Ayşenur7", LastName="Aydın7", Password="123456", Enabled=true, RoleId=2},
         new() { Id=10,Email="ays10@ayd.com",FirstName="Ayşenur2", LastName="Aydın2", Password="123456", Enabled=true, RoleId=2}
       }
   );
      modelBuilder.Entity<Seller>().HasData(

         new Seller { Id = 11, Email = "ays11@ayd.com", FirstName = "Ayşenur5", LastName = "Aydın5", Password = "123456", Enabled = true, RoleId = 1 },
         new Seller { Id = 12, Email = "ays12@ayd.com", FirstName = "Ayşenur6", LastName = "Aydın6", Password = "123456", Enabled = true, RoleId = 1 },
         new Seller { Id = 13, Email = "ays13@ayd.com", FirstName = "Ayşenur7", LastName = "Aydın7", Password = "123456", Enabled = true, RoleId = 1 }

      );
      modelBuilder.Entity<Category>().HasData(
          new List<Category>() {
           new() { Id=1, Name="dress", Color="pink"},
           new() { Id=2, Name="jean", Color="red"},
           new() { Id=3, Name="Sweatshirt", Color="blue"},
           new() { Id=4, Name="Sweatpants", Color="yellow"},
           new() { Id=5, Name="Jumper", Color="black"},
           new() { Id=6, Name="Cardigan", Color="white"},
           new() { Id=7, Name="Outerwear", Color="gray"},
           new() { Id=8, Name="Trousers", Color="darkred"},
           new() { Id=9, Name="Shirt", Color="blue"},
           new() { Id=10, Name="T-shirt", Color="white"}
          }
      );
      modelBuilder.Entity<Product>().HasData(
        new List<Product>() {
           new Product { Id=1, Name="Product 1", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=11, Enabled=true, IsConfirmed= true, CategoryId=1},
           new Product { Id=2, Name="Product 2", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=11, Enabled=false, IsConfirmed= true, CategoryId=2},
           new Product { Id=3, Name="Product 3", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=11, Enabled=true, IsConfirmed= true, CategoryId=3},
           new Product { Id=4, Name="Product 4", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=11, Enabled=true, IsConfirmed= true, CategoryId=4},
           new Product { Id=5, Name="Product 5", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=11, Enabled=false, IsConfirmed= true, CategoryId=5},
           new Product { Id=6, Name="Product 6", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=11, Enabled=true, IsConfirmed= true, CategoryId=6},
           new Product { Id=7, Name="Product 7", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=11, Enabled=true, IsConfirmed= true, CategoryId=7},
           new Product { Id=8, Name="Product 8", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=11, Enabled=false, IsConfirmed= true, CategoryId=8},
           new Product { Id=9, Name="Product 9", Price=10, Details="ürün açıklama", StockAmount=10,   SellerId=12, Enabled=false, IsConfirmed= true, CategoryId=9},
           new Product { Id=10, Name="Product 10", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=12, Enabled=true, IsConfirmed= true, CategoryId=10},
           new Product { Id=11, Name="Product 11", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=12, Enabled=true, IsConfirmed= true, CategoryId=2},
           new Product { Id=12, Name="Product 12", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=12, Enabled=false, IsConfirmed= true, CategoryId=4},
           new Product { Id=13, Name="Product 13", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=12, Enabled=true, IsConfirmed= true, CategoryId=6},
           new Product { Id=14, Name="Product 14", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=12, Enabled=true, IsConfirmed= true, CategoryId=8},
           new Product { Id=15, Name="Product 15", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=13, Enabled=false, IsConfirmed= true, CategoryId=10},
           new Product { Id=16, Name="Product 16", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=13, Enabled=false, IsConfirmed= true, CategoryId=4},
           new Product { Id=17, Name="Product 17", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=13, Enabled=true, IsConfirmed= true, CategoryId=6},
           new Product { Id=18, Name="Product 18", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=12, Enabled=true, IsConfirmed= true, CategoryId=8},
           new Product { Id=19, Name="Product 19", Price=10, Details="ürün açıklama", StockAmount=10, SellerId=12, Enabled=false, IsConfirmed= true, CategoryId=10}
        }
     );

      modelBuilder.Entity<ProductComment>().HasData(
          new ProductComment { Id = 1, Text = "Great product!", StarCount = 5, UserId = 1, ProductId = 1, IsConfirmed = true },
          new ProductComment { Id = 2, Text = "Great product!", StarCount = 5, UserId = 2, ProductId = 2, IsConfirmed = true },
          new ProductComment { Id = 3, Text = "Great product!", StarCount = 3, UserId = 3, ProductId = 3, IsConfirmed = true },
          new ProductComment { Id = 4, Text = "Great product!", StarCount = 5, UserId = 4, ProductId = 4, IsConfirmed = true },
          new ProductComment { Id = 5, Text = "Great product!", StarCount = 5, UserId = 5, ProductId = 5, IsConfirmed = true },
          new ProductComment { Id = 6, Text = "Great product!", StarCount = 1, UserId = 6, ProductId = 6, IsConfirmed = true },
          new ProductComment { Id = 7, Text = "Great product!", StarCount = 5, UserId = 7, ProductId = 7, IsConfirmed = true },
          new ProductComment { Id = 8, Text = "Great product!", StarCount = 5, UserId = 8, ProductId = 8, IsConfirmed = true },
          new ProductComment { Id = 9, Text = "Great product!", StarCount = 5, UserId = 9, ProductId = 9, IsConfirmed = true },
          new ProductComment { Id = 10, Text = "Great product!", StarCount = 4, UserId = 10, ProductId = 10, IsConfirmed = true },
          new ProductComment { Id = 11, Text = "Great product!", StarCount = 5, UserId = 1, ProductId = 11, IsConfirmed = true },
          new ProductComment { Id = 12, Text = "Great product!", StarCount = 5, UserId = 2, ProductId = 12, IsConfirmed = true },
          new ProductComment { Id = 13, Text = "Great product!", StarCount = 5, UserId = 3, ProductId = 13, IsConfirmed = true },
          new ProductComment { Id = 14, Text = "Great product!", StarCount = 5, UserId = 4, ProductId = 14, IsConfirmed = true },
          new ProductComment { Id = 15, Text = "Nice product!", StarCount = 4, UserId = 2, ProductId = 15, IsConfirmed = true }
      );

      modelBuilder.Entity<ProductImage>().HasData(
          new ProductImage { Id = 1, Url = "/product-01.jpg", ProductId = 1, SellerId = 11 },
          new ProductImage { Id = 2, Url = "/product-01.jpg", ProductId = 1, SellerId = 11 },
          new ProductImage { Id = 3, Url = "/product-01.jpg", ProductId = 1, SellerId = 11 },

          new ProductImage { Id = 4, Url = "/product-02.jpg", ProductId = 2, SellerId = 11 },
          new ProductImage { Id = 5, Url = "/product-02.jpg", ProductId = 2, SellerId = 11 },
          new ProductImage { Id = 6, Url = "/product-02.jpg", ProductId = 2, SellerId = 11 },

          new ProductImage { Id = 7, Url = "/product-03.jpg", ProductId = 3, SellerId = 11 },
          new ProductImage { Id = 8, Url = "/product-03.jpg", ProductId = 3, SellerId = 11 },
          new ProductImage { Id = 9, Url = "/product-03.jpg", ProductId = 3, SellerId = 11 },

          new ProductImage { Id = 10, Url = "product-04.jpg", ProductId = 4, SellerId = 11 },
          new ProductImage { Id = 11, Url = "product-04.jpg", ProductId = 4, SellerId = 11 },
          new ProductImage { Id = 12, Url = "product-04.jpg", ProductId = 4, SellerId = 11 },

          new ProductImage { Id = 13, Url = "product-05.jpg", ProductId = 5, SellerId = 11 },
          new ProductImage { Id = 14, Url = "product-05.jpg", ProductId = 5, SellerId = 11 },
          new ProductImage { Id = 15, Url = "product-05.jpg", ProductId = 5, SellerId = 11 },

          new ProductImage { Id = 16, Url = "product-06.jpg", ProductId = 6, SellerId = 11 },
          new ProductImage { Id = 17, Url = "product-06.jpg", ProductId = 6, SellerId = 11 },
          new ProductImage { Id = 18, Url = "product-06.jpg", ProductId = 6, SellerId = 11 },

          new ProductImage { Id = 19, Url = "product-07.jpg", ProductId = 7, SellerId = 12 },
          new ProductImage { Id = 20, Url = "product-07.jpg", ProductId = 7, SellerId = 12 },
          new ProductImage { Id = 21, Url = "product-07.jpg", ProductId = 7, SellerId = 12 },

          new ProductImage { Id = 22, Url = "product-08.jpg", ProductId = 8, SellerId = 12 },
          new ProductImage { Id = 23, Url = "product-08.jpg", ProductId = 8, SellerId = 12 },
          new ProductImage { Id = 24, Url = "product-08.jpg", ProductId = 8, SellerId = 12 },

          new ProductImage { Id = 25, Url = "product-09.jpg", ProductId = 9, SellerId = 12 },
          new ProductImage { Id = 26, Url = "product-09.jpg", ProductId = 9, SellerId = 12 },
          new ProductImage { Id = 27, Url = "product-09.jpg", ProductId = 9, SellerId = 12 },

          new ProductImage { Id = 28, Url = "product-10.jpg", ProductId = 10, SellerId = 12 },
          new ProductImage { Id = 29, Url = "product-10.jpg", ProductId = 10, SellerId = 12 },
          new ProductImage { Id = 30, Url = "product-10.jpg", ProductId = 10, SellerId = 12 },

          new ProductImage { Id = 31, Url = "product-11.jpg", ProductId = 11, SellerId = 12 },
          new ProductImage { Id = 32, Url = "product-11.jpg", ProductId = 11, SellerId = 12 },
          new ProductImage { Id = 33, Url = "product-11.jpg", ProductId = 11, SellerId = 12 },

          new ProductImage { Id = 34, Url = "product-12.jpg", ProductId = 12, SellerId = 12 },
          new ProductImage { Id = 35, Url = "product-12.jpg", ProductId = 12, SellerId = 12 },
          new ProductImage { Id = 36, Url = "product-12.jpg", ProductId = 12, SellerId = 12 },

          new ProductImage { Id = 37, Url = "product-13.jpg", ProductId = 13, SellerId = 13 },
          new ProductImage { Id = 38, Url = "product-13.jpg", ProductId = 13, SellerId = 13 },
          new ProductImage { Id = 39, Url = "product-13.jpg", ProductId = 13, SellerId = 13 },

          new ProductImage { Id = 40, Url = "product-14.jpg", ProductId = 14, SellerId = 13 },
          new ProductImage { Id = 41, Url = "product-14.jpg", ProductId = 14, SellerId = 13 },
          new ProductImage { Id = 42, Url = "product-14.jpg", ProductId = 14, SellerId = 13 },

          new ProductImage { Id = 43, Url = "product-15.jpg", ProductId = 15, SellerId = 13 },
          new ProductImage { Id = 44, Url = "product-15.jpg", ProductId = 15, SellerId = 13 },
          new ProductImage { Id = 45, Url = "product-15.jpg", ProductId = 15, SellerId = 13 },

          new ProductImage { Id = 46, Url = "product-16.jpg", ProductId = 16, SellerId = 13 },
          new ProductImage { Id = 47, Url = "product-16.jpg", ProductId = 16, SellerId = 13 },
          new ProductImage { Id = 48, Url = "product-16.jpg", ProductId = 16, SellerId = 13 },

          new ProductImage { Id = 49, Url = "product-17.jpg", ProductId = 17, SellerId = 13 },
          new ProductImage { Id = 50, Url = "product-17.jpg", ProductId = 17, SellerId = 13 },
          new ProductImage { Id = 51, Url = "product-17.jpg", ProductId = 17, SellerId = 13 },

          new ProductImage { Id = 52, Url = "product-18.jpg", ProductId = 18, SellerId = 13 },
          new ProductImage { Id = 53, Url = "product-18.jpg", ProductId = 18, SellerId = 13 },
          new ProductImage { Id = 54, Url = "product-18.jpg", ProductId = 18, SellerId = 13 },

          new ProductImage { Id = 55, Url = "product-19.jpg", ProductId = 19, SellerId = 13 },
          new ProductImage { Id = 56, Url = "product-19.jpg", ProductId = 19, SellerId = 13 },
          new ProductImage { Id = 57, Url = "product-19.jpg", ProductId = 19, SellerId = 13 }

      );
      modelBuilder.Entity<Order>().HasData(
          new Order { Id = 1, OrderCode = "ORD001", Address = "456 Elm St", UserId = 9 },
          new Order { Id = 2, OrderCode = "ORD002", Address = "789 Oak St", UserId = 10 }
      );

      modelBuilder.Entity<OrderItem>().HasData(
          new OrderItem { Id = 1, Quantity = 2, UnitPrice = 10.99m, ProductId = 1, OrderId = 1, SellerId = 11 },
          new OrderItem { Id = 2, Quantity = 1, UnitPrice = 19.99m, ProductId = 2, OrderId = 2, SellerId = 12 }
      );

      modelBuilder.Entity<CartItem>().HasData(
          new CartItem { Id = 1, Quantity = 1, ProductId = 1, UserId = 1 },
          new CartItem { Id = 2, Quantity = 1, ProductId = 3, UserId = 2 },
          new CartItem { Id = 3, Quantity = 3, ProductId = 2, UserId = 3 },
          new CartItem { Id = 4, Quantity = 1, ProductId = 4, UserId = 4 },
          new CartItem { Id = 5, Quantity = 1, ProductId = 5, UserId = 5 },
          new CartItem { Id = 6, Quantity = 3, ProductId = 6, UserId = 6 },
          new CartItem { Id = 7, Quantity = 1, ProductId = 7, UserId = 7 },
          new CartItem { Id = 8, Quantity = 1, ProductId = 8, UserId = 8 },
          new CartItem { Id = 9, Quantity = 3, ProductId = 9, UserId = 9 },
          new CartItem { Id = 10, Quantity = 1, ProductId = 3, UserId = 10 },
          new CartItem { Id = 11, Quantity = 1, ProductId = 4, UserId = 7 },
          new CartItem { Id = 12, Quantity = 3, ProductId = 8, UserId = 2 },
          new CartItem { Id = 13, Quantity = 1, ProductId = 2, UserId = 1 },
          new CartItem { Id = 14, Quantity = 1, ProductId = 1, UserId = 3 },
          new CartItem { Id = 15, Quantity = 3, ProductId = 3, UserId = 4 },
          new CartItem { Id = 16, Quantity = 3, ProductId = 2, UserId = 7 }
      );
    }
  }
}


