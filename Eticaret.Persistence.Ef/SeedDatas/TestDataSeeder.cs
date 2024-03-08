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
            modelBuilder.Entity<User>().HasData(
                new List<User>() {
                      new() { Id=1, Email="ays@ayd.com",FirstName="Ayşenur", LastName="Aydın", Password="123456", Enabled=true, RoleId=3}
                }
            );
        }
    }
}