using System;
using System.Collections.Generic;
using System.Text;

namespace WorkplaceDAL.Models
{
    public class Warehouse:BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
    }
}
