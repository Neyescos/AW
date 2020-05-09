using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkplaceBLL.DTO
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public ImageDTO Picture { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public WarehouseDTO WarehouseId { get; set; }
        public UserDTO UserId { get; set; }
    }
}
