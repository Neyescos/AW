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
        
        public WorkPlaceContext()
        {
        }
        public WorkPlaceContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User
            {
                Name = "admin",
                Password = "admin",
                Role = "Admin"
            }); ;

        }
    }
        
     
}
