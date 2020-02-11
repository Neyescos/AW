using System;
using System.Collections.Generic;
using System.Text;

namespace WorkplaceBLL.DTO
{
    class WarehouseDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public DateTime Date { get; set; }
    }
}
