using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomizedWorkplace.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<ProductModel> Products { get; set; }
        public string Role { get; set; }
    }
}
