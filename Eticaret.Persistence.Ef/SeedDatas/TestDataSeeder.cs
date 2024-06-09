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
           new() { Id=1, Name="seller", NormalizedName="SELLER"},
           new() { Id=2, Name="buyer", NormalizedName="BUYER"},
           new() { Id=3, Name="admin", NormalizedName="ADMIN"}
        }
      );
      modelBuilder.Entity<User>().HasData(
       new List<User>() {
         new() { Id=1, Email="aysenur@aydin.com",FirstName="Admin",LastName="Admin", PasswordHash="123456", Enabled=true, RoleId=3},

         new() { Id=2, Email="ays2@ayd.com",FirstName="Ayşenur4", LastName="Aydın4", PasswordHash="123456", Enabled=true, RoleId=2},
         new() { Id=3, Email="ays3@ayd.com",FirstName="Ayşenur5", LastName="Aydın5", PasswordHash="123456", Enabled=true, RoleId=2},
         new() { Id=4, Email="ays4@ayd.com",FirstName="Ayşenur6", LastName="Aydın6", PasswordHash="123456", Enabled=true, RoleId=2},
         new() { Id=5, Email="ays5@ayd.com",FirstName="Ayşenur7", LastName="Aydın7", PasswordHash="123456", Enabled=true, RoleId=2},
         new() { Id=6, Email="ays6@ayd.com",FirstName="Ayşenur4", LastName="Aydın4", PasswordHash="123456", Enabled=true, RoleId=2},
         new() { Id=7, Email="ays7@ayd.com",FirstName="Ayşenur5", LastName="Aydın5", PasswordHash="123456", Enabled=true, RoleId=2},
         new() { Id=8, Email="ays8@ayd.com",FirstName="Ayşenur6", LastName="Aydın6", PasswordHash="123456", Enabled=true, RoleId=2},
         new() { Id=9, Email="ays9@ayd.com",FirstName="Ayşenur7", LastName="Aydın7", PasswordHash="123456", Enabled=true, RoleId=2},
         new() { Id=10,Email="ays10@ayd.com",FirstName="Ayşenur2", LastName="Aydın2", PasswordHash="123456", Enabled=true, RoleId=2},

         new()  { Id = 11, Email="ays11@ayd.com",FirstName="Ayşenur5",LastName="Aydın5",PasswordHash="123456",Enabled=true, RoleId=1},
         new()  { Id = 12, Email="ays12@ayd.com",FirstName="Ayşenur6",LastName="Aydın6",PasswordHash="123456",Enabled=true, RoleId=1},
         new()  { Id = 13, Email="ays13@ayd.com",FirstName="Ayşenur7",LastName="Aydın7",PasswordHash="123456",Enabled=true, RoleId=1}
}
      );
      modelBuilder.Entity<Category>().HasData(
          new List<Category>() {
           new() { Id=1, Name="Yelek", Color="	#a4b2b0"},
           new() { Id=2, Name="Triko", Color="	#896863	"},
           new() { Id=3, Name="Sweatshirt", Color="#C27D42	"},
           new() { Id=4, Name="Şort", Color="	#BF8882	"},
           new() { Id=5, Name="Kazak", Color="	#A4B2B0	"},
           new() { Id=6, Name="Elbise", Color="#828DE5"},
           new() { Id=7, Name="Ceket", Color="#595B56	"},
           new() { Id=8, Name="Pantolon", Color="	#CDC6C3	"},
           new() { Id=9, Name="Etek", Color="#DEBDB0"},
           new() { Id=10, Name="Bluz", Color="	#BE969B	"}
          }
      );
      modelBuilder.Entity<Product>().HasData(
        new List<Product>() {
           new Product { Id=1, Name="Yelek 1", Price=619, Details="ürün açıklama", StockAmount=10,   UserId=12, Enabled=true, IsConfirmed= true, CategoryId=1},
           new Product { Id=2, Name="Yelek 2", Price=619, Details="ürün açıklama", StockAmount=10,   UserId=12, Enabled=false, IsConfirmed= true, CategoryId=1},
           new Product { Id=3, Name="Yelek 3", Price=510, Details="ürün açıklama", StockAmount=10,   UserId=12, Enabled=true, IsConfirmed= true, CategoryId=1},

           new Product { Id=4, Name="Triko 1", Price=700, Details="ürün açıklama", StockAmount=10,   UserId=13, Enabled=true, IsConfirmed= true, CategoryId=2},
           new Product { Id=5, Name="Triko 2", Price=700, Details="ürün açıklama", StockAmount=10,   UserId=13, Enabled=false, IsConfirmed= true, CategoryId=2},
           new Product { Id=6, Name="Triko 3", Price=700, Details="ürün açıklama", StockAmount=10,   UserId=13, Enabled=false, IsConfirmed= true, CategoryId=2},

           new Product { Id=7, Name="Sweatshirt 1", Price=320, Details="ürün açıklama", StockAmount=10,   UserId=12, Enabled=true, IsConfirmed= true, CategoryId=3},
           new Product { Id=8, Name="Sweatshirt 2", Price=450, Details="ürün açıklama", StockAmount=10,   UserId=12, Enabled=false, IsConfirmed= true, CategoryId=3},
           new Product { Id=9, Name="Sweatshirt 3", Price=600, Details="ürün açıklama", StockAmount=10,   UserId=12, Enabled=true, IsConfirmed= true, CategoryId=3},

           new Product { Id=10, Name="Şort 1", Price=900, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=true, IsConfirmed= true, CategoryId=4},
           new Product { Id=11, Name="Şort 2", Price=900, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=true, IsConfirmed= true, CategoryId=4},
           new Product { Id=12, Name="Şort 3", Price=900, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=false, IsConfirmed= true, CategoryId=4},
           new Product { Id=13, Name="Şort 4", Price=900, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=false, IsConfirmed= false, CategoryId=4},
           new Product { Id=14, Name="Şort 5", Price=900, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=false, IsConfirmed= true, CategoryId=4},

           new Product { Id=15, Name="Kazak 1", Price=300, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= true, CategoryId=5},
           new Product { Id=16, Name="Kazak 2", Price=300, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= true, CategoryId=5},
           new Product { Id=17, Name="Kazak 3", Price=300, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=false, IsConfirmed= false, CategoryId=5},

           new Product { Id=18, Name="Elbise 1", Price=500, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= false, CategoryId=6},
           new Product { Id=19, Name="Elbise 2", Price=500, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= true, CategoryId=6},
           new Product { Id=20, Name="Elbise 3", Price=500, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=false, IsConfirmed= true, CategoryId=6},
           new Product { Id=21, Name="Elbise 4", Price=500, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=false, IsConfirmed= true, CategoryId=6},

           new Product { Id=22, Name="Ceket 1", Price=360, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=true, IsConfirmed= true, CategoryId=7},
           new Product { Id=23, Name="Ceket 2", Price=360, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=true, IsConfirmed= false, CategoryId=7},
           new Product { Id=24, Name="Ceket 3", Price=360, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=false, IsConfirmed= true, CategoryId=7},
           new Product { Id=25, Name="Ceket 4", Price=360, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=false, IsConfirmed= true, CategoryId=7},

           new Product { Id=26, Name="Pantolon 1", Price=400, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= true, CategoryId=8},
           new Product { Id=27, Name="Pantolon 2", Price=400, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=false, IsConfirmed= true, CategoryId=8},
           new Product { Id=28, Name="Pantolon 3", Price=400, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= false, CategoryId=8},
           new Product { Id=29, Name="Pantolon 4", Price=400, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=false, IsConfirmed= true, CategoryId=8},

           new Product { Id=30, Name="Etek 1", Price=550, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=true, IsConfirmed= true, CategoryId=9},
           new Product { Id=31, Name="Etek 2", Price=550, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=true, IsConfirmed= true,  CategoryId=9},
           new Product { Id=32, Name="Etek 3", Price=550, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=true, IsConfirmed= false, CategoryId=9},
           new Product { Id=33, Name="Etek 4", Price=550, Details="ürün açıklama", StockAmount=10, UserId=13, Enabled=true, IsConfirmed= true, CategoryId=9},

           new Product { Id=34, Name="Bluz 1", Price=450, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=false, IsConfirmed= true, CategoryId=10},
           new Product { Id=35, Name="Bluz 2", Price=450, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= false, CategoryId=10},
           new Product { Id=36, Name="Bluz 3", Price=450, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= true, CategoryId=10},
           new Product { Id=37, Name="Bluz 4", Price=450, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=true, IsConfirmed= true, CategoryId=10},
           new Product { Id=38, Name="Bluz 5", Price=450, Details="ürün açıklama", StockAmount=10, UserId=12, Enabled=false, IsConfirmed= true, CategoryId=10}
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
          new ProductImage { Id = 1, Url = "yelek-01.jpg", ProductId = 1, UserId = 12 },
          new ProductImage { Id = 2, Url = "yelek-02.jpg", ProductId = 2, UserId = 12 },
          new ProductImage { Id = 3, Url = "yelek-03.jpg", ProductId = 3, UserId = 12 },

          new ProductImage { Id = 4, Url = "triko-01.jpg", ProductId = 4, UserId = 13 },
          new ProductImage { Id = 5, Url = "triko-02.jpg", ProductId = 5, UserId = 13 },
          new ProductImage { Id = 6, Url = "triko-03.jpg", ProductId = 6, UserId = 13 },

          new ProductImage { Id = 7, Url = "sweatshirt-01.jpg", ProductId = 7, UserId = 12 },
          new ProductImage { Id = 8, Url = "sweatshirt-02.jpg", ProductId = 8, UserId = 12 },
          new ProductImage { Id = 9, Url = "sweatshirt-03.jpg", ProductId = 9, UserId = 12 },

          new ProductImage { Id = 10, Url = "sort-01.jpg", ProductId = 10, UserId = 13 },
          new ProductImage { Id = 11, Url = "sort-02.jpg", ProductId = 11, UserId = 13 },
          new ProductImage { Id = 12, Url = "sort-03.jpg", ProductId = 12, UserId = 13 },
          new ProductImage { Id = 13, Url = "sort-04.jpg", ProductId = 13, UserId = 13 },
          new ProductImage { Id = 14, Url = "sort-05.jpg", ProductId = 14, UserId = 13 },

          new ProductImage { Id = 15, Url = "kazak-01.jpg", ProductId = 15, UserId = 12 },
          new ProductImage { Id = 16, Url = "kazak-02.jpg", ProductId = 16, UserId = 12 },
          new ProductImage { Id = 17, Url = "kazak-03.jpg", ProductId = 17, UserId = 12 },

          new ProductImage { Id = 18, Url = "elbise-01.jpg", ProductId = 18, UserId = 12 },
          new ProductImage { Id = 19, Url = "elbise-02.jpg", ProductId = 19, UserId = 12 },
          new ProductImage { Id = 20, Url = "elbise-03.jpg", ProductId = 20, UserId = 12 },
          new ProductImage { Id = 21, Url = "elbise-04.jpg", ProductId = 21, UserId = 12 },

          new ProductImage { Id = 22, Url = "ceket-01.jpg", ProductId = 22, UserId = 13 },
          new ProductImage { Id = 23, Url = "ceket-02.jpg", ProductId = 23, UserId = 13 },
          new ProductImage { Id = 24, Url = "ceket-03.jpg", ProductId = 24, UserId = 13 },
          new ProductImage { Id = 25, Url = "ceket-04.jpg", ProductId = 25, UserId = 13 },

          new ProductImage { Id = 26, Url = "pantolon-01.jpg", ProductId = 26, UserId = 12 },
          new ProductImage { Id = 27, Url = "pantolon-02.jpg", ProductId = 27, UserId = 12 },
          new ProductImage { Id = 28, Url = "pantolon-03.jpg", ProductId = 28, UserId = 12 },
          new ProductImage { Id = 29, Url = "pantolon-01.jpg", ProductId = 29, UserId = 12 },

          new ProductImage { Id = 30, Url = "etek-01.jpg", ProductId = 30, UserId = 13 },
          new ProductImage { Id = 31, Url = "etek-02.jpg", ProductId = 31, UserId = 13 },
          new ProductImage { Id = 32, Url = "etek-03.jpg", ProductId = 32, UserId = 13 },
          new ProductImage { Id = 33, Url = "etek-04.jpg", ProductId = 33, UserId = 13 },

          new ProductImage { Id = 34, Url = "bluz-01.jpg", ProductId = 34, UserId = 12 },
          new ProductImage { Id = 35, Url = "bluz-02.jpg", ProductId = 35, UserId = 12 },
          new ProductImage { Id = 36, Url = "bluz-03.jpg", ProductId = 36, UserId = 12 },
          new ProductImage { Id = 37, Url = "bluz-04.jpg", ProductId = 37, UserId = 12 },
          new ProductImage { Id = 38, Url = "bluz-05.jpg", ProductId = 38, UserId = 12 }

      );


    }
  }
}


