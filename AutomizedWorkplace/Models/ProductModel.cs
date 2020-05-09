using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutomizedWorkplace.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public int ImageId { get; set; }
        public ImageModel Picture { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public WarehouseModel WarehouseId { get; set; }
        public UserModel UserId { get; set; }
    }
}
