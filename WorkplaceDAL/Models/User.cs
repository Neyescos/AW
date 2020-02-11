using System;
using System.Collections.Generic;
using System.Text;

namespace WorkplaceDAL.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Product> Products { get; set; }
        public Role Role { get; set; }
    }
}
