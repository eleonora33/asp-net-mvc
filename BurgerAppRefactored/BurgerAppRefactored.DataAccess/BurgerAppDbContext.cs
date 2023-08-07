using BurgerAppRefactored.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerAppRefactored.DataAccess
{
    public class BurgerAppDbContext : DbContext
    {
        public BurgerAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Burger> Burgers { get; set; }
        
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Burger>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Burger)
                .HasForeignKey(x => x.BurgerId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Burger>()
                .HasData(new Burger
                {
                    Id = 1,
                    Name = "Name1",
                    HasFries = true,
                    IsVegetarian = true,
                    IsVegan = true,
                    Price = 100,
                },
                new Burger
                {
                    Id = 2,
                    Name = "Name2",
                    HasFries = false,
                    IsVegetarian = false,
                    IsVegan = false,
                    Price = 150,
                }
                );

            modelBuilder.Entity<Order>()
                .HasData(new Order
                {
                    Id = 1,
                    FullName = "Name Toso",
                    IsDelivered = true,
                    Location = "Karpos",
                    Address = "Vlae"
                },
                new Order
                {
                    Id = 2,
                    FullName = "Name Eleonora",
                    IsDelivered = false,
                    Location = "Karpos",
                    Address = "Vlae"
                });

            modelBuilder.Entity<BurgerOrder>()
                .HasData(new BurgerOrder
                {
                    Id = 1,
                    BurgerId = 1,
                    OrderId = 2,
                    Price = 250,
                    Quantity = 1,
                },
                new BurgerOrder
                {
                    Id = 2,
                    BurgerId = 2,
                    OrderId = 1,
                    Price = 500,
                    Quantity = 2,
                });
        }
    }
}
