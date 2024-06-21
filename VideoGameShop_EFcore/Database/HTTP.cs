using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace VideoGameShop.Database
{
    public class HTTP : DbContext
    {
        public DbSet<Client> client { get; set; }
        public DbSet<ShopAssortment> shop_assortment { get; set; }
        public DbSet<UserOrder> user_order { get; set; }
        public HTTP()
        {
            Database.EnsureCreated();
        }

        // Установка соединения с БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;"+
            "Port=5432;"+
            "Database=VideoGame_Shop;"+
            "Username=administrator;"+
            "Password=123456;" +
            "Pooling=true;");
        }
    }
}