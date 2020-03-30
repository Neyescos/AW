using System;
using System.Collections.Generic;
using System.Text;

namespace WorkplaceDAL.Models
{
    public class Image:BaseEntity
    {
        public string Url { get; set; }
        public Product ProductId { get; set; }
    }
}
