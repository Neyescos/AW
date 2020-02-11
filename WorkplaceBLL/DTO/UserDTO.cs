using System;
using System.Collections.Generic;
using System.Text;

namespace WorkplaceBLL.DTO
{
    class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<ProductDTO> Products { get; set; }
        public RoleDTO Role { get; set; }
    }
}
