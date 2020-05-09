using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceDAL.Models;

namespace WorkplaceDAL.EF
{
    public class WorkPlaceContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        
        public WorkPlaceContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "admin",
                Password = "admin",
                Role = "Admin"
            });

            modelBuilder.Entity<Product>().HasOne(t => t.Picture).WithOne(t => t.Product).HasForeignKey<Image>(t => t.ProductId);
            modelBuilder.Entity<Product>().HasOne(t => t.WarehouseId).WithOne(t => t.Product).HasForeignKey<Warehouse>(t => t.ProductId);
            modelBuilder.Entity<Product>().HasOne(t => t.UserId).WithMany(t => t.Products);


        }
    }
        
     
}
