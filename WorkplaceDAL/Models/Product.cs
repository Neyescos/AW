using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceDAL.Models;

namespace WorkplaceDAL
{
   public class Product:BaseEntity
   {
        public string Name { get; set; }
        public Image Picture { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Warehouse WarehouseId { get; set; }
        public User UserId { get; set; }
   }
}
