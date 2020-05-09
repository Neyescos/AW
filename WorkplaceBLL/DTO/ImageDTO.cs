using System;
using System.Collections.Generic;
using System.Text;

namespace WorkplaceBLL.DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
