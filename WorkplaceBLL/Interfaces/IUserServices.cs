using System;
using System.Collections.Generic;
using System.Text;
using WorkplaceBLL.DTO;

namespace WorkplaceBLL.Interfaces
{
    interface IUserServices
    {
        void MakeUser(UserDTO userDTO);
        UserDTO GetUser(int? id);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();

    }
}
