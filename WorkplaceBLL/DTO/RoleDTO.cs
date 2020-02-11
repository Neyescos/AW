using System;
using System.Collections.Generic;
using System.Text;

namespace WorkplaceBLL.DTO
{
    class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserDTO> Users { get; set; }
    }
}
