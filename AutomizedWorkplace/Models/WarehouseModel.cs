using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomizedWorkplace.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public DateTime Date { get; set; }
    }
}
