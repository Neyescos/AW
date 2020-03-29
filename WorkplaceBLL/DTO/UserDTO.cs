using System;
using System.Collections.Generic;
using System.Text;

namespace WorkplaceBLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<ProductDTO> Products { get; set; }
        public string Role { get; set; }
    }
}
